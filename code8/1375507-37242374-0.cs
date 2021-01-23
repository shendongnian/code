    private void ThreadFunc() {
            do {
                if( !stop ) {
                    WorkDelegate workItem = null;
                    lock( workLock ) {
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
