    var groupedByBucket = ListOfSuperBuckets
        .SelectMany(c => c.buckets)
        .GroupJoin(items, a => a.id, b => b.bucketId, new
            {
                bucket = a,
                items = b
            });
    foreach (var g in groupedByBucket)
    {
        // We benefit here from that the collection types are passed by reference.
        // We don't have to even know which Super Bucket these things came from.
        g.bucket.AddRange(g.items);
    }
