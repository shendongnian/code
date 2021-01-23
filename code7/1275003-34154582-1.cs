    volatile int curWordStartIndex; //I use this global variable to communication between the progressChanged event and findBit, called from the DoWork event
    
    private void Form1_Load(object sender, EventArgs e)
    {
        backgroundWorker1.WorkerReportsProgress = true;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        //As far as richTextBox1.TextLength provokes a cross-thread error, I pass it as an argument
        backgroundWorker1.RunWorkerAsync(richTextBox1.TextLength);
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        findBit((int)e.Argument);
    }
    
    private void findBit(int textLength)
    {
        string[] words = new string[] { "word1", "word2", "word3", "word4", "word5" };
        foreach (string word in words)
        {
            int startIndex = 0;
            while (startIndex < textLength)
            {
                //Rather than performing the actions affecting the GUI thread here, I pass all the variables I need to
                //the ProgressChanged event through ReportProgress and perform the modifications there.
                backgroundWorker1.ReportProgress(0, new object[] { word, startIndex, Color.Yellow });
                if (curWordStartIndex == -1) break;
    
                startIndex += curWordStartIndex + word.Length;
            }
        }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        object[] curVars = (object[])e.UserState;
        
        richTextBox1.SuspendLayout(); 
    
        string word = (string)curVars[0];
        int startIndex = (int)curVars[1];
        Color curColor = (Color)curVars[2];
        curWordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);
    
        if (curWordStartIndex != -1)
        {
            richTextBox1.SelectionStart = curWordStartIndex;
            richTextBox1.SelectionLength = word.Length;
            richTextBox1.SelectionBackColor = curColor;
        }
    
        richTextBox1.ResumeLayout();
    }
 
