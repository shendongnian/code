             if (tempUnamePhone.Count != 0)
            {
                showBlock.Text = "item found" + fname;      
                statusBar.IsIndeterminate = false;
                searchButton.IsEnabled = true;
            }
            else
            {
                showBlock.Text = "no match found";
                statusBar.IsIndeterminate = false;
                searchButton.IsEnabled = true;
            }
