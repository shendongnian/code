    this is going to work.
   
 
      string str = @"1,717.72    1,728.89    1,712.61    1,728.89    1,707.11
        1,717.72    1,728.89    1,712.61    1,728.89    1,707.11";
        
                  var doubles =   str.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(item =>
                        item.Split("    ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(d => double.Parse(d)).ToArray()).ToArray();
