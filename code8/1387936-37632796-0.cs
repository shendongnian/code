    async Task AddItem(Block block, Item item) {
        var updateDefinition = Builders<Block>.Update
            .AddToSet(b => b.ListOfItems, item);
    
        var result = await blocksCollection.UpdateOneAsync(
            b => b.BlockId == block.BlockId, updateDefinition);
    static object locker = new object();
        // however the synchronous version works:
        // var result = blocksCollection.UpdateOneAsync(
        //      b => b.BlockId == block.BlockId, updateDefinition).Result;
    lock(locker)
       {
        if (result.ModifiedCount != 1)
            throw new DbException();
       }
    }
