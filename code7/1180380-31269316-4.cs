        private void LoadTree()
        {
            ObservableCollection<xTreeViewItem> treeSource = new ObservableCollection<xTreeViewItem>();
            List<xTreeViewItem> Buffer = new List<xTreeViewItem>();
            foreach (DataRow row in table.Rows)
            {
                 xTreeViewItem itm = new TreeViewItem();
                 // Load the required heirarchial data
                 Buffer.Add(itm);
            }
            for (int i = Buffer.Count - 1; i >= 0; i--)
            {
                if (Buffer[i].parentID != 0)
                {
                    if (Buffer[i].ParentResolved)
                        Buffer.RemoveAt(i);
                    else
                    {
                        Buffer[i].ParentResolved = true;
                        while (Buffer.Any(c => (c.parentID == Buffer[i].menuID && !c.ParentResolved)))
                        {
                            Buffer[i].children.Add(FindChildren(Buffer[i]));
                        }
                        xTreeViewItem parent = Buffer.First(c => c.menuID == Buffer[i].parentID);
                        parent.children.Add(Buffer[i]);
                        Buffer[i].parent = parent;
                        Buffer.RemoveAt(i);
                    }
                }
            }
            // remaining items acts as mainItems, so add it to the treeSource
            foreach (xTreeViewItem x in Buffer)
            {
                 treeSource.Add(x);
            }
            treeView.ItemsSource = treeSource;
        }
        
        xTreeViewItem FindChildren(xMenuItem x)
        {
            List<xTreeViewItem > subBuffer = Buffer.Where(c => (c.parentID == x.menuID && !c.ParentResolved)).ToList(); // if there is, get all of them to a list
            subBuffer = subBuffer.OrderBy(c => c.order).ToList();    // << THIS IS CRAZY, BUT FIXES :P // order all of them by their 'order' property
            int indx = Buffer.IndexOf(subBuffer[0]);                                                    // get the first item after ordering
           
            Buffer[indx].ParentResolved = true;
            Buffer[indx].parent = x;                // changing parentresolved property to prevent infinte loops
            while (Buffer.Any(c => (c.parentID == Buffer[indx].menuID && !c.ParentResolved))) // again checking if the current child got any other child.
            {
                Buffer[indx].children.Add(FindChildren(Buffer[indx])); // adding all the childs                     
            }
            return Buffer[indx]; // return the child
        }
