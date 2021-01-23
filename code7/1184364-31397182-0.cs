        int? maxVal = null; // ? means nullable int. Set null just to initialize
        
        for (int i = 0; i < nums.Length; i++)
        {
          int currentNum = nums[i];
          if (!maxVal.HasValue || thisNum > maxVal.Value)
          {
            maxVal = thisNum;
          }
        }
    
       Console.WriteLine(maxVal);
