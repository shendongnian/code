    static void Main(string[] args)
    {
         Uploader upl = new Uploader();
         var res = upl.Upload(10).Result;
    }
    public class Uploader 
    {
        async public Task<int> Upload(int i)
        {
            int incremented = 0;
            var t = UploadToServer(i);
            if (t != null)
            {
                incremented = await t;
            }
            return incremented;
        }
    
        private async Task<int> UploadToServer(int i)
        {
            return await Task.Run(() => DoSomething(i));
        }
    
        private int DoSomething(int i)
        {
            //Console.ReadLine();
            //Actual upload operation
            Thread.Sleep(2000);
            return i + 1;
        }
    }
