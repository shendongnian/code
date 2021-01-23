     // this is UI bound
     public string Data
     {
         get { return GetData().Result; }
     }
     static async Task<string> GetData() {
         await Task.Run(() =>
         {
             Thread.Sleep(2000);
         });
         return "test!";
     }
