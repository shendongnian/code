    public Form1()
    {
        InitializeComponent();
        textBox1.Text = "This is my text where I want to check how I can get wrapped content as seperate lines automatically !! This is my text which I want to check how I can get wrapped content as seperate lines automatically !!";
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        bool continueProcess = true;
        int i = 1; //Zero Based So Start from 1
        int j = 0;
        List<string> lines = new List<string>();
        while (continueProcess)
        {
            var index = textBox1.GetFirstCharIndexFromLine(i);
            if (index != -1)
            {
                lines.Add(textBox1.Text.Substring(j, index - j));
                j = index;
                i++;
            }
            else
            {
                lines.Add(textBox1.Text.Substring(j, textBox1.Text.Length - j));
                continueProcess = false;
            }
        }
        foreach(var item in lines)
        {
            MessageBox.Show(item);
        }
    }
