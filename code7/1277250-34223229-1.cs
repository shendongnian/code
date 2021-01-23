    var pairsToUpdate = from original in vmlist
                        join item in vlist
                          on new { original.SId, original.ParameterId, original.WId }
                          equals new { item.SId, item.ParameterId, item.WId }
                        select new { original, item };
    foreach (var pair in pairsToUpdate)
    {
        pair.original.Value = pair.item.Value;
    }
