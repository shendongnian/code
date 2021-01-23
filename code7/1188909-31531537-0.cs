    class ExpiringItem
    {
        private string text;
        public ExpiringItem(string text)
        {
            this.text = text;
            this.Added = DateTime.Now;
        }
        public DateTime Added { get; private set; }
        public override string ToString()
        {
            return text;
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        for (int i = listBox1.Items.Count -1; i > -1; i--)
        {
            var exp = (ExpiringItem)listBox1.Items[i];
            var timeVisible = DateTime.Now - exp.Added;
            if (timeVisible.TotalSeconds > 30)
                listBox1.Items.RemoveAt(i);
        }
    }
