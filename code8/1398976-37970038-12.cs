    private void btnSeparate_Click(object sender, EventArgs e)
    {
        // Save how many words are inside
        int wordsInText = txtFullName.Text.Split(' ').Length;
        // Save if "stop" was typed into the textbox
        bool stopExisting = !txtFullName.Text.ToLower().Contains("stop");
    
        // If text has exactly 3 words and "stop" is NOT existing
        if (wordsInText == 3 && !stopExisting)
        {
            // Save array of splitted parts
            string[] nameParts = txtFullName.Text.Split(' ');
                    
            // This is never used??
            string strfirstname = nameParts[1];
    
            // Set name-parts to labels
            lblGivenEntered.Text = nameParts[0];
            lblFamilyEntered.Text = nameParts[2];
        }
        // If text has NOT exactly 3 words and "stop" is NOT existing
        else if(wordsInText != 3 && !stopExisting)
        {
            // If there are no 3 words, handle it here - MessageBox?
        }
        // If "stop" IS existing
        else if(stopExisting)
        {
            // If text contains "stop" handle it here
            // Application.Exit(); <-- if you really want to exit
        }
    }
