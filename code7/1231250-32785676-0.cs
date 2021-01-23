     var myString = "ls 0 
        [0,86,180]
        ls 1 
        [1,2,200]
        ls 2 
        [2,3,180]
        ls 3 
        [3,4,234]";
        
        RegEx pattern = new RegEx(@"\[[\d,]*\]*");
        Match numbers = pattern.Match(myString);
        
        if(numbers.Success)
        {
          do {
              var val = numbers.Value;
              
              // code for each block of numbers
    
              numbers.NextMatch();
              } while(numbers.Success)
        }
