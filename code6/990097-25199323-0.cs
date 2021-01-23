    public void SumUpValues(CollMyKeyValue collection)
    {
        //int count =0;
        Parallel.For(0, this.Count, 
            (i) => 
                {
                    this[i].Value = this[i].Value + collection[i].Value;
                    //Interlocked.Increment(ref count);
                });  
    }
