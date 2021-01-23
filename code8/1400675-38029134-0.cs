       public async Task<bool> Remove()
        {
            for (int i = activeQueue.Count; i>=0; i++)
            {
                var aq = activeQueue[i];
                var canRemove = await aq.Value.CanRemove();
                if (canRemove)
                {
                    activeQueue.RemoveAt(i);
                }                    
            }           
            
            return passiveQueue.IsEmpty && activeQueue.Count == 0;
        }
