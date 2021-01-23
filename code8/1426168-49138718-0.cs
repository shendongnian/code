        public static Task PipeTo<T>(this Task<T> taskToPipe, ICanTell recipient, IActorRef sender = null, Func<T, object> success = null, Func<Exception, object> failure = null)
        {
            sender = sender ?? ActorRefs.NoSender;
            return taskToPipe.ContinueWith(tresult =>
            {
                if (tresult.IsCanceled || tresult.IsFaulted)
                    recipient.Tell(failure != null
                        ? failure(tresult.Exception)
                        : new Status.Failure(tresult.Exception), sender);
                else if (tresult.IsCompleted)
                    recipient.Tell(success != null
                        ? success(tresult.Result)
                        : tresult.Result, sender);
            }, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }
