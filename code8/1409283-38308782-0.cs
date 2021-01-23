        private void Search_Button_Click(object sender, EventArgs e)
        {
            // Use regex to find the text, this will return the whole line with
            // the whole line as Group[0], and the actual search text as Group[2]
            var searchRegex = new Regex($"(.*?)({Search_Text_Box.Text})(.*?)");
            // Returns all the matches
            var searchMatches = searchRegex.Matches(Display_Rich_Text_Box.Text);
            // To get the number of matches
            var searchCount = searchMatches.Count;
            // To get the text from the whole line
            foreach (Match searchMatch in searchMatches)
            {
                //Searches and locates the text you are searching for
                Display_Rich_Text_Box.Find(Search_Text_Box.Text, searchMatch.Group[2].Index, Display_Rich_Text_Box.TextLength, RichTextBoxFinds.None);
                //Color Selection: Hightlights in yellow
                Display_Rich_Text_Box.SelectionBackColor = Color.Yellow;
                // Do whatever you want with the names
                var wholeName = searchMatch.Groups[0].ToString();
            }
            Form2 f = new Form2(searchCount);
            f.ShowDialog();
        }
