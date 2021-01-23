    string x = "<ul><table>..</table><h1>dfds</h1><li>sfd</li></ul>";
    htmlDoc.LoadHtml(x);
    HtmlNodeCollection hNC = htmlDoc.DocumentNode.SelectNodes("//ul/*");
    foreach (HtmlNode h in hNC)
    {
        if(h.Name != "li")
        {
            Console.WriteLine("Removes tag: "+h.Name);
            h.Remove();       
        }
    }
   
    Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("/ul").InnerHtml);
