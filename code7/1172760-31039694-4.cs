    List<int> listInteger = new List<int> ();
    
    public SumList (int[] list)
    {
    	for (int i = 0; i < list.Length; i++)
    		listInteger.Add (list [i]);
    	listInteger.Reverse();
    }
    
    private void sumR (List<int> list, int index)
    {
    	int sigma = 0;
    	if (list.Count - 1 == index) {
    		return;// sigma + list [index];
    	} else {
    		for (int i = list.Count-1; i>=index; i--) {
    			sigma += list [i];
    			if (i == list.Count - 1)
    				Console.Write ("{0} ", list [i]);
    			else
    				Console.Write ("+ {0} ", list [i]);
    		}
    		Console.WriteLine ("= {0}", sigma);
    		sumR (list, index + 1);
    	}
    }
    public void doSum(){
    	sumR(listInteger, 0);
    }
