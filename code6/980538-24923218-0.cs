    public void RunCommands(int runid, int batchid)
    {            
        this.FillList(runid, batchid);
        int total = this.sitecollection.Count();
        if (total >= 1500)
        {
            int[][] batches = this.CreateBatch(total);
            Parallel.Invoke(
                () => { this.DoWork(batches[0][0], batches[0][1], runid, batchid); },
                () => { this.DoWork(batches[1][0], batches[1][1], runid, batchid); },
                () => { this.DoWork(batches[2][0], batches[2][1], runid, batchid); },
                () => { this.DoWork(batches[3][0], batches[3][1], runid, batchid); },
                () => { this.DoWork(batches[4][0], batches[4][1], runid, batchid); }
            );
        }
    }
    public delegate void AsyncThreads(int batchstart, int batchend, int runid, int batchid);
    public void DoWork(int batchstart, int batchend, int runid, int batchid)
    {
      //do some work
    }
