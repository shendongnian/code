    [Serializable]
    public class TobeSerialized
    {
        private long idHandleValue;
        [NonSerialized]
        private ObjectId id;
    
        public TobeSerialized()
        {
            this.idHandleValue = id.Handle.Value;
        }
    public ObjectId GetObjectId(Database database, long handleValue)
        {
            Handle handle = new Handle(handleValue);
            ObjectId id = database.GetObjectId(false, handle, 0);
            return id;
        }
    }
