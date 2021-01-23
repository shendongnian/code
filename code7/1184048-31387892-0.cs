    var s = db.Users.Select(x =>  x.Name.Substring(0,1)).FirstOrDefault();
    
    telList.Items.Clear();
    
    for (int i = 0; i < alpha.Length; i++) {
        var listItem = new ListItem(Convert.ToString(alpha[i]));
        listItem.Attributes.Add("value", Convert.ToString(i));
    
        if (Convert.ToString(i) == s) {
            listItem.Attributes.Add("class", "class2");
        } else {
            listItem.Attributes.Add("class", "class1");
        }
        telList.Items.Add(listItem);
    }
