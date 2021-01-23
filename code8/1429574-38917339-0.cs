    public class Repository : Server
    { 
    
    }
    
    public class Repositories<T> where T: Server
    { 
        private List<T> theList = new List<T>();
        public Repositories<T>(List<T> theList) this.theList = theList; }
        public BindingList<T> ToBindingList()
        {
            BindingList<T> myBindingList = new BindingList<T>();
    
            foreach (Titem in this.theList)
            {
                _bl.Add(item);
            }
    
            return _bl;
    
        }   
    }
