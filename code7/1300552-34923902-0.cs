                var s = "STX,T1,ETXSTX,1,1,1,1,1,1,ETXSTX,A,1,0,B,ERRETX";
                s = s.Replace("STX", "\u0002");
                s = s.Replace("ETX", "\u0003");
    
                var result1 = Regex.Split(s, @"[\u0002\u0003]").Where(a => a != String.Empty).ToList();
                result1.ForEach(a=>Console.WriteLine(a));
    
                Console.WriteLine("------------ OR WITHOUT REGEX ---------------");
    
                var result2 = s.Split(new char[] { '\u0002','\u0003' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                result2.ForEach(a => Console.WriteLine(a));
