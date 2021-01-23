    class Vector<T>
        {
            Dictionary<int,T> list;
    
            public Vector ()
    	    {
               this.list = new Dictionary<int,T>();
    	    }
          
            public T this [int index]{
                get
                {
                    if (list.ContainsKey(index))
                        return list[index];
                    else return default(T);
                }
                set {
                    if (list.ContainsKey(index))
                        list[index] = value;
                    else 
                        list.Add(index,value);
                }
               
            } 
        }
