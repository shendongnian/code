    var status = message.BodyParts.OfType<MimePart>.Where (x => x.ContentType.Matches ("message", "delivery-status")).FirstOrDefault ();
    if (status != null) {
        using (var content = status.ContentObject.Open ()) {
            // since the content of a message/delivery-status MIME part has
            // the same format as message headers, we can re-use the header
            // parser to save us some effort.
            var info = HeaderList.Load (content);
    
            // TODO: take a look at the specific "headers" to get the info we 
            // care about. For more info on what these header field names and
            // values are, take a look at https://tools.ietf.org/html/rfc3464
        }
    }
