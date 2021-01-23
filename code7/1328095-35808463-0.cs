    //Newest by date/time and take x (e.g. 5)
    foreach (var item in feed.Items.OrderByDescending(i => i.PublishDate).Take(5))
    {
         //Get the Uris from SyndicationLink
         var theLinks = item.Links.Select(l => l.Uri.ToString()).ToList();
         //do something with them....
         var foo = string.Join(",", theLinks);
    
        ....
    }
