        wsvListTagHistoryClass item = new wsvListTagHistoryClass();
    	item.TagId = (int)reader[0];
    	item.GroupId = (int)reader[1];
    	item.GroupName = reader[2].ToString();
    	item.Entered = reader[3].ToString();
    	item.DHours = reader[4].ToString();
    	item.GPS = reader[5].ToString();
    	return View(item);
