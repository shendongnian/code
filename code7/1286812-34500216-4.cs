    var ListOfSuperBuckets = items
        .GroupBy(c => new { c.bucketId, c.sBucketId })
        .GroupBy(c => c.Key.sBucketId)
        .Select(c => new SuperBucket
            {
                id = c.Key,
                buckets = c.Select(b => new Bucket
                    {
                        id = b.Key.bucketId,
                        items = b.ToList()
                    }).ToList()
            })
        .ToList();
