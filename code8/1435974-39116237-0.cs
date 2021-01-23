        List<int> a = new List<int>();
        
        int n = 2; // you can change it according to your need
        
                  
    
      for (int i = 0; i < n; i++)
                {
                    string str = Console.ReadLine(); // make sure you enter an integer and conver it
                    int z = int.Parse(str);
    
                    a.Add(z);
                }
    
                foreach (int k in a)
                {
                    Console.WriteLine(k);
                }
