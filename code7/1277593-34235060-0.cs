       private static async void CallWebService(string url)
       {
              try
              {
                  using (MailSorterServiceClient client = new MailSorterServiceClient())
                   {
                       var result = await client.GetUrlAsync(url);
                       Console.WriteLine(result.ToString());
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.InnerException.Message);
                   Console.WriteLine(ex.InnerException.StackTrace);
               }
         }
