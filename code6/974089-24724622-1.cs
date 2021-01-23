    for (int i = 0; i < currMaxValues; i ++)
            {
                //new placeholdernames
                string currPlaceholderTime = "placeholderTime" + i;
                string currPlaceholderMore = "placeholderZusatz" + i;
                string currPlaceholderIco = "placeholderIco" + i;
                string currPlaceholderTemp = "placeholderTemp" + i;
    
                //elements for placeholders
                Label time = null;
                Label more = null;
                Image img = null;
                Label temp = null;
    
                //built the stuff for the placeholders
                DateTime currTime = DateTime.Now;
                int hour = currTime.Hour;
                time.Text = hour.ToString();
    
                Placeholder placeHolderTime = FindControl(currPlaceholderTime) as PlaceHolder;
                placeHolderTime.Controls.Add(time);
                
                //(PlaceHolder)currPlaceholderTime.Controls.add(time);
            }
