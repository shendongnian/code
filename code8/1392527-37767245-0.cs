    int temp = 0;
	List<List<int>> allFactors = new List<List<int>>();
	List<int> tempList = new List<int>();
	var total = allFactors.Select(x => x.Select(y => 
                    { 
                        temp += y;    
                          tempList.Add(y); 
                          return y; 
                    })).ToList();
