                var mainDictionary = new Dictionary<int, Dictionary<string, List<int>>>();
                var firstInnerDictionary = new Dictionary<string, List<int>>();
                var secondInnerDictionary = new Dictionary<string, List<int>>();
    
                firstInnerDictionary.Add("first", new List<int>{4,24,5,0});
                mainDictionary.Add(100, firstInnerDictionary);
                
                secondInnerDictionary.Add("first", new List<int>{4,24,5,0});
                mainDictionary.Add(500, firstInnerDictionary);
