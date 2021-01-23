    var s = @"ABC-123, 80000, 1400 
            ABC-123, 70000, 1250 
            ABC-123, 65000, 1200 
            BCD-234, 90000, 1300
            BCD-234, 95000, 1100
            XYZ-111, 24000, 1000
            XYZ-111, 24000, 1000";
    
    var ss = s.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)  //split by newlines
               .Select(x => x.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)) //Split each line by ,
               .GroupBy(y => y[0]); //group by first element of array
                
