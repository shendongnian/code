     SignedRequestHelper helper = new SignedRequestHelper("XXXXXXXXXX", "XXXXXXXXXXXXXXXXXXX", "webservices.amazon.com");
     IDictionary < string, string > dictValue = new Dictionary < string, String > ();
     dictValue["Service"] = "AWSECommerceService";
     dictValue["Version"] = "2011-08-01";
     dictValue["Operation"] = "ItemLookup";
     dictValue["ItemId"] = asinCode;
     dictValue["IdType"] = "ASIN";
     dictValue["AssociateTag"] = "xxxxxxxxx-xx";
     dictValue["ResponseGroup"] = "ItemAttributes";
     string url = helper.Sign(dictValue)
     WebRequest request = WebRequest.Create(url);
     string price;
     using(WebResponse response = await request.GetResponseAsync()) {
     	if (response != null) {
     		using(XmlReader reader = XmlReader.Create(response.GetResponseStream())) {
     			// Now parse XML  accordingly
     			reader.ReadToFollowing("ListPrice")
     			if (reader.ReadToDescendant("FormattedPrice")) {
     				price = reader.ReadElementContentAsString();
