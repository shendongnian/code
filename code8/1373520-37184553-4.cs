    List<TextBox> alreadyClickedTextBoxes = new List<TextBox>();
    
    ScoreList_Click(object sender, MouseButtonEventArgs e) {
        TextBox x = e.OriginalSource as TextBox;
        
        //check this is a text box, and has not been clicked
        if (x != null && !alreadyClickedTextBoxes.Contains(x))
        {
            MessageBox.Show("Don't try this at home Kiddo");
            
            if (x.Text == "1" || x.Text == "2" || x.Text == "3" || x.Text == "4")
            {
                x.Text = "10";
                x.IsEnabled = false;
            }
            //we don't want to click this again
            alreadyClickedTextBoxes.Add(x);
        }
    }
