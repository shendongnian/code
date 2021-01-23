            private void TitlesBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                ComboBox box = sender as ComboBox;
                if (box.SelectedIndex >= 0)
                {
                    OutputBox.DocumentText = ((List<string>)(box.Items[box.SelectedIndex]))[1];
                    linkLabel.Text = "GoTo: " + ((List<string>)(box.Items[box.SelectedIndex]))[0];
                }
     
            }
    ​
