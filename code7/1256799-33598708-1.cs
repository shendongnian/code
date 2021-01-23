    private void button1_Click(object sender, EventArgs e)
    {
        Counter myCounter = new Counter(this, 1000);
        myCounter.IndexValueChanged += myCounter_IndexValueChanged;
        myCounter.StartCountAsync();
    }
