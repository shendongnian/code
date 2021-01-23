    private void ThreadFunc() {
       do {
            if( !stop ) {
                WorkDelegate workItem = null;
                lock( workLock ) {
                    if( Monitor.Wait(workLock, WaitTimeout) ) {
                        workItem = (WorkDelegate) workQueue.Dequeue();
                    }
                }
                if (workItem != null) workItem();
            }
        } while( !stop );
    }
    public void SubmitWorkItem( WorkDelegate item ) 
    {
        lock( workLock ) {
            workQueue.Enqueue( item );
            Monitor.Pulse( workLock );
        }
    }
