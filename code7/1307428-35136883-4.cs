    private async Task ThrowingMethodAsync()
    {
        throw new Exception(); //This would cause the exception to be thrown and observed on 
                               // the calling thread even if ConfigureAwait(false) was used.
                               // on the calling method.
    }
    private async Task ThrowingMethodAsync2()
    {
        await Task.Delay(1000);
        throw new Exception(); //This would cause the exception to be thrown on the SynchronizationContext
                               // thread (UI) but observed on the thread determined by ConfigureAwait
                               // being true or false in the calling method.
    }
    private async Task ThrowingMethodAsync3()
    {
        await Task.Delay(1000).ConfigureAwait(false);
        throw new Exception(); //This would cause the exception to be thrown on the threadpool
                               // thread but observed on the thread determined by ConfigureAwait
                               // being true or false in the calling method.
    }
