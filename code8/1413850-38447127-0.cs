	var doc = XDocument.Load(fileDestination);
    //we're going to select a sequence of items that contain 2 values...
    //the element we want to change and the value we want to store in it
	var changes= doc.Root
					.Elements("DEAL")
					.Descendants("SellerLoanIdentifier")
                    //from each SellerLoanIdentifier in DEAL elements
					.Select(e=>new{
                        //the node we want to change
                        //in this case we get the parent LOAN
                        //element, take the last of the elements
                        //that precede it in the document
                        //and find in it a descendant of type
                        //BuydownInformation
						nodeToChange = e.Ancestors("LOAN")
										.Single()
										.ElementsBeforeSelf()
										.Last()
										.Descendants("BuydownInformation")
										.Single(),
                        //the string value of the current element
						val = (string)e
					});
    //then apply the changes back to the document
	foreach(var change in changes)
	{
		change.nodeToChange.Value = change.val;
	}
    var newXmlString = doc.ToString();
