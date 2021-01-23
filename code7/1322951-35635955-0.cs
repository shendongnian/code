    class MyConcreteClass : MyAbstractClass
    {
        public override IList<NotifyingDatabaseObjectChildClass> GetList<NotifyingDatabaseObjectChild>(int? id)
        {
            return new List<NotifyingDatabaseObjectChildClass>();
        }
    }
