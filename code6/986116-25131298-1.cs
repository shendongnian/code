        private void viewer1_HyperLink(object sender, GrapeCity.ActiveReports.Viewer.Win.HyperLinkEventArgs e)
        {
            if (e.HyperLink == "a")
            {
                MessageBox.Show("TextBox1 Clicked");
            }
            else
            {
                MessageBox.Show("TextBox2 Clicked");
            }
        }
