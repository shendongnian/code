    class Serie: IEnumerable<decimal>
    {
        List<Serie> mylist = new List<Serie>();
    
        public Serie this[int index]  
        {  
            get { return mylist[index]; }  
            set { mylist.Insert(index, value); }  
        } 
    
        public IEnumerator<decimal> GetEnumerator()
        {
            return mylist.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
