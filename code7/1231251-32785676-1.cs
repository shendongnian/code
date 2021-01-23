     var myString = "ls 0 
        [0,86,190]
        ls 1 
        [1,2,300]
        ls 2 
        [2,3,185]
        ls 3 
        [3,4,2345]";
        
        Regex pattern = new Regex(@"\[[\d,]*\]*");
        Match numbers = pattern.Match(myString);
        
        if(numbers.Success)
        {
          do {
              var val = numbers.Value;
              
              // code for each block of numbers
    
              numbers.NextMatch();
              } while(numbers.Success)
        }
