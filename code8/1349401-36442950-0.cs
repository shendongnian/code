    private void _RehashIfNecessary ( )
    {
    	// if the number of strings in the set exceeds the number of buckets, 
    	// increase the number of buckets to either double its current size 
    	// or the largest number of buckets possible, whichever is smaller
    	if ( this._numStrings > this._Buckets.Count )
    	{
    		List<List<string>> NewBuckets = new List<List<string>>(Math.Min(this._Buckets.Count * 2, Int32.MaxValue));
    
    		// this is missing.
    		foreach ( var s in this._Buckets )
    		{
    			NewBuckets.Add(new List<string>());
    		}
    		
    		foreach ( List<string> Bucket in this._Buckets )
    		{
    			foreach ( string s in Bucket )
    			{						
    				NewBuckets[this._GetBucketNumber(s, NewBuckets)].Add(s);
    			}
    		}
    		this._Buckets = NewBuckets;
    	}
    }
