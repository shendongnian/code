    for (int i = 0; i < labelArray.Length; i++)
    {
        labelArray[i].BackColor = Color.Blue;
        labelArray[i].Click += label_Click;
    }
    void label_Click(object sender, EventArgs e)
    {
        string name = ((Label)sender).Name;
    }
