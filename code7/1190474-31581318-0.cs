    var blocksResult = blocks.Where(x => x.BlockName == NAVIGATION);
    if (blocksResult.Any())
    {
        var blockData = db.Pages.Select(x => x.Name).ToList();
        blocksResult.ForEach(block => block.Data = blockData);
    }
