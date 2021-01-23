        foreach (XmlNode xnod in Blist)
        {
            XmlElement buyNode = xnod.SelectSingleNode("/buy"));
            XmlElement sellNode = xnod.SelectSingleNode("/sell"));
            if (xnod.Attributes["id"] != null)
            {
                arr[0] = xnod.Attributes["id"].InnerText;
                arr[1] = buyNode.SelectSingleNode("max").InnerText;
                arr[2] = sellNode.SelectSingleNode("max").InnerText;
            }
            itm = new ListViewItem(arr);
            itm.Font = new Font("Tahima", 9);
            listView1_Jita.Items.Add(itm);  
         }    
                
