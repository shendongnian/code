        private void Form3_Load(object sender, EventArgs e)
        {
            RecentFileMenuItem recentItem = new RecentFileMenuItem("foo");
            mnuFileOpenRecentList.DropDownItems.Add(recentItem);
            recentItem.Recent += new RecentEventHandler(Show); 
        }
        // method signature that matches our RecentEventHandler delegate
        public void Show(object s, RecentEventArgs e)
        {
            MessageBox.Show(e.FileName);
        }
