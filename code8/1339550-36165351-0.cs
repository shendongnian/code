     private static async Task<int> RunALotAsync()
     {
         // For CPU bound work use Task.Run, Alternate is Task.Factory.StartNew
         return await Task.Run(() =>
         {
             int temp = 0;
             for (int ini = 0; ini <= 40000; ini++)
             {
                 temp += ini;
             }
             return temp;
         });
     }
