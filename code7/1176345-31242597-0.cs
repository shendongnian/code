    Batch batch = new Batch { id = BatchId, ... }
    foreach (int i=0; i<n; ++i)
    {
       batch.AddSample(new Sample { id = SampleId+i, batchid = BatchId, ... });
    }
    
    // Update db
    context.Batches.InsertOnSubmit(batch);
    context.SubmitChanges();
