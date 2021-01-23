    _processingBlock.Completion.ContinueWith(
        task =>
        {
          if (task.IsFaulted)
            ((IDataflowBlock)_messageBufferBlock).Fault(task.Exception);
          else if (!task.IsCanceled)
            _messageBufferBlock.Complete();
        },
        CancellationToken.None,
        TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
