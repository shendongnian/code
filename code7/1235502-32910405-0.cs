     Regex regex = new Regex(@"\s{2,}");
     var lines = File.ReadLines(path);
     foreach (var line in lines)
     {
         var item = regex.Split(line,2);
         if(item != null && item.Count > 0)
         {
              Console.WriteLine(regex.Split(line,2)[1]);
              File.WriteAllText(regex.Split(line,2)[1]);   
         }                 
     }
