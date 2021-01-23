    var result =
        scrapeData
        .Select(scr => 
            new
            {
                SCR = scr,
                AWS = 
                    awsData
                    .FirstOrDefault(aws =>
                        scr.MPN == aws.ItemPartNumber ||
                        scr.MPN == aws.Model ||
                        scr.MPN == aws.MPN ||
                        scr.MPN == aws.PartNumber)
            })
        .Where(x => x.AWS != null)
        .Select(x => new Scrape
        {
            EAN = x.AWS.EAN,
            MPN = x.SCR.MPN,
            Url = x.SCR.Url,
        });
