            public int FindMyTextleft(string txtToSearch, int searchStart, int searchEnd)
        {
            // Set the return value to -1 by default.
            int retVal = -1;
            // A valid starting index should be specified.
            if (searchStart >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = richTextBox.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.Reverse);
                    // Determine whether the text was found in richTextBox1.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }
                }
            }//end FindMyTextleft
            return retVal;
        }//end FindMyText
        private void buttonSearch_left_Click(object sender, EventArgs e)
        {
            int startindex = 0;
            if (txtSearch.Text.Length > 0 & stringfoundflag == 1)
            {
                startindex = FindMyTextleft(txtSearch.Text, startindex, end);
            }
            else if (txtSearch.Text.Length > 0)
            {
                startindex = FindMyTextleft(txtSearch.Text, start, richTextBox.Text.Length);
            }
            // If string was not found report it
            if (startindex < 0)
            {
                if (stringfoundflag == 1)
                {
                    startindex = FindMyTextleft(txtSearch.Text, 0, richTextBox.Text.Length); //Start at Pos. 0
                }
                else
                {
                    MessageBox.Show("Not found in Textfield", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }//end if 
            if (startindex >= 0)
            {
                stringfoundflag = 1;
                // Set the highlight color as red
                //richTextBox.SelectionColor = Color.Red;
                // Find the end index. End Index = number of characters in textbox
                int endindex = txtSearch.Text.Length;
                // Highlight the search string
                richTextBox.Select(startindex, endindex);
                // mark the start position after the position of
                // last search string
                end = startindex;
            }
        }//buttonSearch_left_Click
