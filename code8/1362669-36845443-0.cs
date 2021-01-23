    int selectedIndex=-1;
    public editWord(int value)
    {
        InitializeComponent();
        selectedIndex = value;
    }
    private void wordTextBox_TextChanged(object sender, EventArgs e)
    {
        string word = (dictionaryDataSet1.Tables[0].Rows[selectedIndex]["Word"].ToString());
        wordTextBox.Text = word;
    }
