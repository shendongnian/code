    _contextProvider.BeforeSaveEntitiesDelegate = BeforeSaveEntities;
    
    private Dictionary<Type, List<EntityInfo>> BeforeSaveEntities(Dictionary<Type, List<EntityInfo>> arg)
            {
                var resultToReturn = new Dictionary<Type, List<EntityInfo>>();
                foreach (var type in arg.Keys)
                {
                    var entityName = type.FullName;
                    var list = arg[type];
                    if (entityName == "xyz" && list[0].EntityState!="Added")
                    {
                        resultToReturn.Add(type, list);
                    }
                }
                return arg;
            }
