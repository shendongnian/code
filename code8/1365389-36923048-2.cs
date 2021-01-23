	using (var ctx = new DatabaseEntities())
	{
		var webId = item.ShoppingCartWebId.ToString();
		var webIdLength = webId.Length;
		
		if (!ctx.CustomerInboxes.Any(m => m.CustomerId == customerId
			&& m.Reference == item.ShoppingCartWebId.ToString()
			&& m.SubjectId == HerdbookConstants.PendingCartMessage
			&& (m.Reference.Length > webIdLength || (m.Reference.Length == webIdLength && string.Compare(m.Reference, webId) > 0))))) {
				//do something special
			}
	}
