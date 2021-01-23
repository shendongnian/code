    object[,] multiDimensionalArray = new object[,]
        {
            {1,2}, //first pair
            {3,4}, //second pair
            {5,6}  //third pair
        };
        Dictionary<object, object> dict = new Dictionary<object, object>();
                    //total number of elements     //number of dimensions
        int pairs = multiDimensionalArray.Length / multiDimensionalArray.Rank; 
                    
                   //or you can use i < multiDimensionalArray.GetLength(0);
        for(int i = 0; i < pairs; i++)
        {
            dict.Add(multiDimensionalArray[i, 0], multiDimensionalArray[i, 1]);
        }
