    public abstract class AbstractSearch
    {
        string _key;
    
        public string Key
        {
            get { return _key; }
            set 
            { 
                if (value == null) throw new ArgumentNullException("Key");
                _key = value;
            }
        }
    
        public abstract Task<IEnumerable<TopicViewModels>> Search();
    }
    
    public class MySearch : AbstractSearch
    {
        public override Task<IEnumerable<TopicViewModels>> Search()
        {
            string key = Key;
            // Start searching...
        }
    }
