            var stateProxy = ActorState.GetState(this.StateManager);
            List<string> keys = stateProxy.PartitionLeases.Keys.ToList();
            foreach(string key in keys)
            {
                if (DateTime.Now - stateProxy.PartitionLeases[key] >= TimeSpan.FromSeconds(60))
                    stateProxy.PartitionLeases.Remove(key);
            }
            stateProxy.Save();
