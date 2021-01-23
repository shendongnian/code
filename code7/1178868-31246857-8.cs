    var mds = message.BodyParts.OfType<MimePart>.Where (x => x.ContentType.Matches ("message", "delivery-status")).FirstOrDefault ();
    if (mds != null) {
        using (var memory = new MemoryStream ()) {
            mds.ContentObject.DecodeTo (memory);
            memory.Position = 0;
            // the content of a message/delivery-status MIME part is a
            // collection of header groups. The first group of headers
            // will contain the per-message status headers while each
            // group after that will contain status headers for a
            // particular recipient.
            var groups = new List<HeaderList> ();
            while (memory.Position < memory.Length)
                groups.Add (HeaderList.Load (memory));
    
            // TODO: take a look at the specific "headers" to get the info we 
            // care about. For more info on what these header field names and
            // values are, take a look at https://tools.ietf.org/html/rfc3464
        }
    }
