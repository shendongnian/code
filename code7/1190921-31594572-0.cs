    string lines = reader.ReadtoEnd();
    
    var result = lines.Split(new string[]{" ","\r\n"},StringSplitOptions.RemoveEmptyEntries)
                      .GroupBy(x=>x)
                      .Select(g=> new 
                                  { 
                                      Alphabet = g.Key , 
                                      Count = g.Count() 
                                   }
                              );
