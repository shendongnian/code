    public class Class
    {
        private List<Document> listdoc = new List<Document>();
        private List<DocumentLookup> listdoclookup = new List<DocumentLookup>();
        private List<DocumentText> listdoctxt = new List<DocumentText>();
    
        public void Deserialize(string property, Stream stream)
        {
            var bformatter = new BinaryFormatter();
            var des = bformatter.Deserialize(stream);
            switch (property)
            {
                case "Document":
                    listdoc.AddToList(des);
                    break;
    
                case "DocumentLookup":
                    listdoclookup.AddToList(des);
                    break;
    
                case "DocumentText":
                    listdoctxt.AddToList(des);
                    break;
    
                default:
                    throw new ArgumentOutOfRangeException("property");
            }
        }
    }
    
    public static class ListDeserializeExts
    {
        public static void AddToList<TValue>(this List<TValue> list, object des)
        {
            list.AddRange((IEnumerable<TValue>)des);
        }
    }
