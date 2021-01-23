     while (a != "end...")
     {
         a = Console.ReadLine();
         if (!a.Equals("end..."))
             newList.Add(a);
     }
            
     string code = string.Join("\r\n", newList);
     string[] source = new string[] { code };
