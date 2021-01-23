    public class DataObject
    {
        public static bool HasData
        {
            get
            {
                return myObject != null;
            }
        }
        public static DataObject PresistentDataObject
        {
            get
            {
                return myObject;
            }
        }
        static DataObject myObject = new DataObject();
    }
