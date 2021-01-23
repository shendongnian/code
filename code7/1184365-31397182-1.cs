        int? maxVal = null; // ? means nullable int. Set null just to initialize
        
        for (int i = 0; i < nums.Length; i++)
        {
          int currentNum = nums[i];
          if (!maxVal.HasValue || currentNum > maxVal.Value)
          {
            maxVal = currentNum;
          }
        }
    
       Console.WriteLine(maxVal);
