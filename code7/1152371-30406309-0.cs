        private void AddPlayerToTreeView(string playerName, string division, DateTime selDate)
        {
            TreeNode tn = new TreeNode();
            string shrtDate = selDate.ToShortDateString();
            //check to see if the date exists (shortdate format)
            // if doesn't exist: create the Night node and call the function recursively
            // if exists, check to see if division exists:
            //   if doesn't exist: create the Division node and call the function recursively
            //   if exists, add player
            TreeNode[] tns = this.tview_roster.Nodes.Find(shrtDate, false); //find the date in the root nodes
            if(tns.Length == 0) //the date doesn't exist in the list
            {
                tn = this.tview_roster.Nodes.Add(shrtDate, shrtDate);
                tn.ImageIndex = 2; //date icon
                this.AddPlayerToTreeView(playerName, division, selDate);
            }
            else //date exists, try to find division within it
            {
                var parentNight = tns[0].Index; //save the index of the night node
                tns = this.tview_roster.Nodes[parentNight].Nodes.Find(division, false); //search child nodes
                if (tns.Length == 0) //division doesn't exist, create it (and child nodes in recursive call)
                {
                    tn = this.tview_roster.Nodes[parentNight].Nodes.Add(division, division);
                    tn.ImageIndex = 1; //division icon
                    this.AddPlayerToTreeView(playerName, division, selDate);
                }
                else //division exists, add player
                {
                    var parentDiv = tns[0].Index; //save the index of the division node
                    tn = this.tview_roster.Nodes[parentNight].Nodes[parentDiv].Nodes.Add(playerName, playerName);
                    tn.ImageIndex = 0; //player icon
                }
            }
        }
