    var bridges = context.TableABBridge.Select(n => new
    {
        n.AId,
        n.BId
    }).Distinct()
    .GroupBy(n => n.BId, n => n.AId).Where(n => n.Count() > 1)
    .Select(n=>n.Key);
    var uneditable = context.TableABBridge.Where(n => bridges.Contains(n.BId)).Select(n => n.AId);
    var editable = context.TableABBridge.Select(n => new
    {
        n.AId,
        n.BId
    }).Distinct()
    .GroupBy(n => n.BId, n => n.AId).Where(n => n.Count() == 1)
    .Select(n => n.FirstOrDefault().Value);
