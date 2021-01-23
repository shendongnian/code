    var query = doc.Elements("checkItem")
                   .Select( x =>
                   new 
                   {
                       CheckAmount = (string) x.Element("checkAmount"),
                       ImageRefKey = (string) x.Element("imageRefKey"),
                       PostingDate = (string) x.Element("dare"),
                       ImageViews = x.Element("ImageView").Elements("ImageViewInfo")
                           .Select(iv=> 
                           new 
                           {
                              Format = iv.Element("Format").Element("Baseline").Value
                              // more parsing here
                           }
                    }
       
