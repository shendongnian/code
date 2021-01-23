    // outside any method:
    private List<string> names = new List<string>();
    void myLoadMethod()
    {
        ...
        foreach(var HandlingName in query)
        {
            //string Names = HandlingName.HandlingName;
            Names.Add(HandlingName.HandlingName);
        }  
    }
    private void button1_Click(object sender, EventArgs e)
    {
        comboBox1.Items.Add( Names);
    }
