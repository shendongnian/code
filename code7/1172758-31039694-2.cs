    List<int> listInteger = new List<int> ();
    
    public SumList (int[] list)
    {
    	for (int i = 0; i < list.Length; i++)
    		listInteger.Add (list [i]);
    	listInteger.Reverse();
    }
    
    private int sumR (List<int> list, int index)
    {
    	int sigma = 0;
    	if (list.Count - 1 == index) {
    		return list [index];
    	} else {
    		sigma += sumR (list, index + 1);
    		
    	  for (int i = list.Count-1; i>=index; i--) {
    			  if (i == list.Count-1)
    				  Console.Write ("{0} ", list [i]);
    			  else
    				  Console.Write ("+ {0} ", list [i]);
    		}
    		sigma += list [index];
    		Console.WriteLine ("= {0}", sigma);
    		return sigma;
    	}
    }
    public void doSum(){
    	sumR(listInteger, 0);
    }
