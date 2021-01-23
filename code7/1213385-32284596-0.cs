    var newHeader = rdr.GetString(3); //it is a reader that contains the current node, for example "Home"
    var exists = false;
    foreach (TreeViewItem item in rootNode.Items) //iterate through all nodes
    {
             var header = item.Header;
             if (header.Equals(newHeader))
             {
                 Console.WriteLine("Item already inserted!!");
                 exists = true;
                 break;
             }
     }
     if (!exists)
     {
           rootNode.Items.Add(new TreeViewItem() { Header = newHeader });
     }
