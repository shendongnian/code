    public async Task<bool> Remove()
        {
            await Task.Run(() => {
                 var itemsToRemove = activeQueue.Where(x => x.Value.CanRemove()).ToArray();
                 foreach(var item in itemsToRemove)
                     activeQueue.Remove(item.Key);
             });
        
            return passiveQueue.IsEmpty && activeQueue.Count == 0;
        }
