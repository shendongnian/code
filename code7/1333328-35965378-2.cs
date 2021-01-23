    XDocument doc = XDocument.Load(file path);
    		
		var nodes = doc.Descendants("user").Select(e=> new ListViewItem( new [] { 
			
			e.Element("username").Value,
    e.Element("USERID").Value,
			
			//e.Element("password").Value,
			e.Element("lastlogon").Value
		})).ToArray();
    UserslistView.Items.AddRange(nodes);
