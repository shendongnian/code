    // First prepare two list with the richtextboxes and the tabpages
    List<RichTextBox> myBoxes = new List<RichTextBox>()
    { richTextBox1, richTextBox2, richTextBox3, richTextBox4, richTextBox5 };
    List<TabPage> myPages = new List<TabPage>()
    { tabPage1, tabPage2, tabPage3, tabPage4, tabPage5};
    // Now open the folderbrowser dialog 
    // (see link above for some of its properties)
    FolderBrowerDialog fbd = new FolderBroserDialog();
    if(fbd.ShowDialog() == DialogResult.OK)
    {
        int i = 0;
        foreach(string file in Directory.GetFiles(fbd.SelectedPath))
        {        
            myBoxes[i].Text = File.ReadAllText(file);
            myPages[i].Text = file;
            i++;
            // Added a warning if the folder contains more than 5 files
            if(i >= 5)
            { 
               MessageBox.Show("Too many files in folder, only 5 loaded");
               break;
            }
         }
     }
