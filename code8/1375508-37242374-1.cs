    private void ThreadFunc() {
            do {
                if( !stop ) {
                    WorkDelegate workItem = null;
                    lock( workLock ) {
                        if (workQueue.Count > 0)
                            workItem = (WorkDelegate) workQueue.Dequeue();
                    }
                    workItem();
                }
            } while( !stop );
        }
    }
    public void SubmitWorkItem( WorkDelegate item ) {
        lock( workLock ) {
                workQueue.Enqueue( item );
        }
    }
