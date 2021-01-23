    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
    	    Dictionary<int, List<int>> graph = new Dictionary <int, List<int>>();
            graph[1] = new List<int> {2, 3, 4};
            graph[2] = new List<int> {1, 3, 4};
            graph[3] = new List<int> {1, 2, 4};
            graph[4] = new List<int> {1, 2, 3, 5};
            graph[5] = new List<int> {4, 6};
            graph[6] = new List<int> {5};
        }
    }
