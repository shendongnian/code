    var blockCount = 0;
    ...
    var blockId = Convert.ToBase64String(BitConverter.GetBytes(blockCount));
    blob.PutBlock(blockId, ms, null);
    blocksCount++;
