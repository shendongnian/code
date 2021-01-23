            string[] tags = new string[] { "A", "B", "C" };
            foreach (string request in tags)
            {
                Label userName = new Label();
                userName.Name = request;
                Button accept = new Button();
                accept.Name = request;
                
                Button reject = new Button();
                reject.Name = request;
                userName.Text = request;
                accept.Text = "Accept";
                reject.Text = "Reject";
                friendRequestPanel.Controls.Add(userName);
                friendRequestPanel.Controls.Add(accept);
                friendRequestPanel.Controls.Add(reject);
            }
            // Just remove the "B"s
            friendRequestPanel.Controls.RemoveByKey("B");
