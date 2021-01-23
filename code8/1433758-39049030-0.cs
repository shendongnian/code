    foreach (User user in this.oSkype.Friends)
            {
                if (user.OnlineStatus == "olsOffline") {
                    this.listBoxControl1.Items.Add(user.Handle + " Offline");
                } else {
                    this.listBoxControl1.Items.Add(user.Handle + " Online");
                }
            }
