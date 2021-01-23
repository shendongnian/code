    // helper class
    private class Entry
    {
        public TextBox TextBox { get; private set; }
        public DateTimePicker DateTimePicker { get; private set; }
        public PictureBox PictureBox { get; private set; }
        public Entry( TextBox tb, DateTimePicker dtp, PictureBox pb )
        {
            this.TextBox = tb;
            this.DateTimePicker = dtp;
            this.PictureBox = pb;
        }
    }
 
    // member field
    private List<Entry> m_Entries = new List<Entry>();
    // at the end of pictureBox1_Click
    public void pictureBox1_Click(object sender, EventArgs e)
    {
        ....
        m_Entries.Add( new Entry( tb, dtp, pb ) );
    }
