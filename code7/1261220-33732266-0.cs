     sw.Start();
     for (int i = 0; i < 1000; i++)
     {  
         regex.IsMatch(message);
     }
     sw.Stop();
      Debug.WriteLine(sw.ElapsedMilliseconds / 1000); 
