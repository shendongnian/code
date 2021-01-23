    static MimeEntity ParseHttpWebResponse (HttpWebResponse response)
    {
        var contentType = ContentType.Parse (response.ContentType);
    
        return MimeEntity.Parse (contentType, response.GetResponseStream ());
    }
    
    static void SaveAllImages (HttpWebResponse response)
    {
        var entity = ParseHttpWebResponse (response);
        var multipart = entity as Multipart;
    
        if (multipart != null) {
            foreach (var image in multipart.OfType<MimePart> ()) {
                using (var memory = new MemoryStream ()) {
                    image.ContentObject.DecodeTo (memory);
    
                    var blob = memory.ToArray ();
    
                    // save it to your database
                }
            }
        }
    }
