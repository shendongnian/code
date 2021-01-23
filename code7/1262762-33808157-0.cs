    var agg = results.Aggs.Terms("term_items");
    if (agg!= null && agg.Items.Count > 0)
    {
        foreach (var termItemAgg in agg.Items)
        {
            // do something with the aggregations
            // the term is accessed using the Key property
            var term = termItemAgg.Key;
            // the count is accessed through the DocCount property
            var count = termItemAgg.Count;
            // now access the result of the sub-aggregation
            var bucketAgg = termItemAgg.Aggs.SignificantTerms("bucket_agg");
            // do something with your sub-aggregation results
        }
    }
