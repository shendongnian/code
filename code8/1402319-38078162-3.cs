    List<newClass> acts = new List<newClass>();
    // assuming length > 0
    int length = (acts.Length  % 2 == 0) ? acts.Length : acts.Length - 1;
    for (int i = 0; i < acts.Length; i += 2)
    {
    	newClass si = new newClass
    	{
    		Name=acts[i].Name,
    		AdditionalData=acts[i].AdditionalData,
    		StartTime = acts[i].ActivityTime ,
    		EndTime = acts[i+1].ActivityTime
    	};
    	items.Add(si);  
    }
    
    if (length < acts.Length)
      // handle the last element as you wish
