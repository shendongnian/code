    char code = "\ue052"[0]; // U+E052 is the first character of the progressring
    
    public Application()
            {
                InitializeComponent();
    
                progressringLabel.Text = code;
            }
    
    private void progressringTimer_Tick(object sender, EventArgs e)
            {
                code++;
                progressring.Text = code.ToString();
                if (code == "\ue0CB"[0])
                {
                    code = "\ue052"[0]; // When the code ends up being the last progressring character, revert back to the first one so that it won't go into the other characters
                }
            }
