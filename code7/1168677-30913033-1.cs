		var types = new List<Type>
            {
                typeof(Smokey),
                typeof(Rasher),
                typeof(Danish)
            };
        
            foreach(var b in bacon) {
                if (types.Any(t => b.GetType() == t)) {
                    selectedBacon.Add(b);
                    types.Remove(b.GetType());
                }
                if (types.Count == 0) {
                    break;
                 }
            }
