    var str =  "0009000A000B000C";
    
    var splitgroup2 = ChunksUpto(str , 4);
    public string[] ChunksUpTo(string str, int count)
    {
       if(count == 0)
          return null;
  
       List<string> result = new List<string>();
       int chunkCount = str.Length / count;
       for(int i = 0; i < temp; i++)
            result.Add(new string(str.Take(count).ToArray()))
       return result;
    }
