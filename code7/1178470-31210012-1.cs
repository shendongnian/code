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
    
    
        public Serie()
        {
    
        }
    
        public Serie(List<decimal> serie)
        {
            mylist = serie;
        }
    
        public Serie Add(decimal Value)
        {
            List<decimal> lst = new List<decimal>();
            for (int i = 0; i < mylist.Count; i++)
            {
                lst.Add(mylist[i]);
            }
            lst.Add(Value);
            Serie S = new Serie(lst);
            return S;
        }
        
        public double Count()
        {
            return mylist.Count;
        }
        
        public static Serie operator +(Serie left, decimal right)
        {
            List<decimal> temp = new List<decimal>();
            for (int i = 0; i < left.Count(); i++)
            {
                temp.Add(left[i] + right);
            }    
            return new Serie(temp);
        }
    }
