    public static class ParentMappings
    {
        public static ChildAVM Map(this ChildA model)
        {
            return new ChildAVM()
                {
                    ParentIdVM = model.ParentId,
                    ParentNameVM = model.ParentName,
                    ChildPropertyAVM = model.ChildPropertyA,
                };
        }
        public static ChildBVM Map(this ChildB model)
        {
            return new ChildBVM()
                {
                    ParentIdVM = model.ParentId,
                    ParentNameVM = model.ParentName,
                    ChildPropertyBVM = model.ChildPropertyB,
                };
        }
        public static ParentVM Map(this Parent model)
        {
            if (model is ChildA)
                return ((ChildA)model).Map();
            else if (model is ChildB)
                return ((ChildB)model).Map();
            else
                return new ParentVM()
                    {
                        ParentIdVM = model.ParentId,
                        ParentNameVM = model.ParentName,
                    };
        }
        public static List<ParentVM> Map(this List<Parent> parents)
        {
            return parents.Select(p => p.Map()).ToList();
        }
    }
