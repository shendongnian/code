    public class MyIndexer
        {
            private string[] myData;
            public string this[int ind]
            {
                get
                {
                    return myData[ind];
                }
                set
                {
                    myData[ind] = value;
                }
            }
        }
    	
    public class UseIndex
    	{
    		public void UseIndexer()
            {            
                MyIndexer ind = new MyIndexer();
        
                ind[1] = "Value 1";
                ind[2] = "Value 2";
                ind[3] = "Value 3";    
    			ind[4] = "Value 4";    
    			ind[5] = "Value 5";    
            }
    	}
