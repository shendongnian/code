    foreach (var dataToPost in privatedictionary)
            {
                Task.Run(async () =>
                {
                    Foo foo = new Foo();
                    await foo.BarAsync(dataToPost);
                });
            }
     
      //Asynchronous Handling
      public class Foo
    {
        public async Task BarAsync(string dataToPost)
        {
            HttpWebRequest wbrq = (HttpWebRequest)WebRequest.Create("www.sitetohit.com");
            {
                using (StreamWriter sw = new StreamWriter(wbrq.GetRequestStream()))
                {
                    await sw.WriteAsync(dataToPost);
                }
            }
        }
    }
