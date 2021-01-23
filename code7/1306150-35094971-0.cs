    public class MyEntityVM
    {
        public MyEntityVM(MyEntity entity)
        {
            this.ItemId = entity.RowKey;
            //etc...
        }
        public string ItemId {get;set;}
        public string GroupId {get;set;}
        public string MyAFieldName {get;set;
    }
