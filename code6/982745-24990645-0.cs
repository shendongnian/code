     for(int i=1;i<=subFolder.Items.Count;i++)
    {
        item = (Microsoft.Office.Interop.Outlook.MailItem)subFolder.Items[i];
        if(item.Body.Contains("errors"))
            {
                Console.WriteLine("Item: {0}", i.ToString());
                Console.WriteLine("Subject: {0}", item.Subject); 
                Console.WriteLine("Sent: {0} {1}",  
                item.SentOn.ToLongDateString(), item.SentOn.ToLongTimeString());
                Console.WriteLine("Categories: {0}", item.Categories);
                Console.WriteLine("Body: {0}", item.Body);
                Console.WriteLine("HTMLBody: {0}", item.HTMLBody); 
            }
    }
