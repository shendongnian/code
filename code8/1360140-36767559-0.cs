    foreach(var t in k.TOP_STANDARD_COSTs)
    {
        t.Id = Guid.NewGuid();
        k.Entry(t).State = System.Data.EntityState.Modified;
    }
    k.SubmitChanges();
