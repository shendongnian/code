    private bool TrySetFromTask(Task task, bool lookForOce)
    {
        Contract.Requires(task != null && task.IsCompleted, "TrySetFromTask: Expected task to have completed.");
        bool result = false;
        switch (task.Status)
        {
            case TaskStatus.Canceled:
                result = TrySetCanceled(task.CancellationToken, task.GetCancellationExceptionDispatchInfo());
                break;
            case TaskStatus.Faulted:
                var edis = task.GetExceptionDispatchInfos();
                ExceptionDispatchInfo oceEdi;
                OperationCanceledException oce;
                if (lookForOce && edis.Count > 0 &&
                    (oceEdi = edis[0]) != null &&
                    (oce = oceEdi.SourceException as OperationCanceledException) != null)
                {
                    result = TrySetCanceled(oce.CancellationToken, oceEdi);
                }
                else
                {
                    result = TrySetException(edis);
                }
                break;
            case TaskStatus.RanToCompletion:
                var taskTResult = task as Task<TResult>;
                result = TrySetResult(taskTResult != null ? taskTResult.Result : default(TResult));
                break;
        }
        return result;
    }
