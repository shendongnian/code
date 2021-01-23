        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item == sender)
            {
                if (e.IsSelected) timer3.Start();
                else timer3.Stop();
            }                        
        }
