    if (ListViewCostumControl.lvnf.SelectedItems.Count > 0)
            {
                var selectedText = ListViewCostumControl.lvnf.Items[ListViewCostumControl.lvnf.SelectedIndices[0]].Text;
                richTextBox1.Text = File.ReadAllText(selectedText);
                FileInfo fi = new FileInfo(selectedText);  //not used!
                   
                string word = textBox1.Text;
                string[] test = word.Split(',');
                foreach (string myword in test)
                {                    
                    HighlightPhrase(richTextBox1, myword, Color.Yellow);
                }
              }
