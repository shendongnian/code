    public Form1()
    { 
        InitializeComponent();
    }
    public string[] fileNames { get; private set; }
    int numberOfFiles { get; set; }
    public void button1_Click(object sender, EventArgs e)
    {
        //Your openFileDialog1 initialisation and other stuff here
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            fileNames = openFileDialog1.SafeFileNames;
            numberOfFiles = fileName.Length;
        }
    }
    public void button2_Click(object sender, EventArgs e)
    {
        foreach (string fileName in fileNames)
        {
            //You can access the name of each file using fileName now
        }
    }
