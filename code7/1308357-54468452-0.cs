    var mimeDocument = new MimeDocument();
    using (var mimeDocumentLoadStream = mimeDocument.GetLoadStream())
    {
    	ConvertAnyMimeToMimeMethod(email.Message.MimeDocument, mimeDocumentLoadStream);
    }
    var convertedEmail = EmailMessage.Create(mimeDocument);
    
    
    private static void ConvertAnyMimeToMimeMethod(MimeDocument documentIn, Stream mimeOut)
    {
    	var assembly = Assembly.Load("Microsoft.Exchange.Data.Storage");
    	var outboundConversionOptionsType = assembly?.GetType("Microsoft.Exchange.Data.Storage.OutboundConversionOptions");
    	var outboundOptionsConstructor = outboundConversionOptionsType?.GetConstructor(
    		BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public,
    		null,
    		new[] { typeof(string) },
    		null);
    	var outboundOptions = outboundOptionsConstructor?.Invoke(new object[] { "OurDomain.tld" });
    	var itemConversionType = assembly?.GetType("Microsoft.Exchange.Data.Storage.ItemConversion");
    	var convertAnyMimeToMimeMethod = itemConversionType?.GetMethod(
    		"ConvertAnyMimeToMime",
    		BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
    		null,
    		new[] { documentIn.GetType(), mimeOut.GetType(), outboundOptions?.GetType() },
    		null);
    		
    	convertAnyMimeToMimeMethod.Invoke(null, new[] { documentIn, mimeOut, outboundOptions });
    }
