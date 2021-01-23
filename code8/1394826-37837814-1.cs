    public string ValueFromForm3
    {
        get;
        private set;
    }
    public void ShowForm3()
    {
        using (Form3 f3 = new Form3())
        {
           if (f3.ShowDialog(this) == DialogResult.OK)
               ValueFromForm3 = f3.TheValueYouNeed;
        }
    }
