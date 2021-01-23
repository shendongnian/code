    class SpecialTextBox : Panel
    {
        TextBox tb = new TextBox();
        public string IdCode {get; set;}
        // simple event, don't register to the inner TextBox!
        public event EventHandler SpecialTBLeave;
        public SpecialTextBox()
        {
            Controls.Add(tb);
            BorderStyle = BorderStyle.FixedSingle;
            Left = 30;
            // register to inner TextBox' event to raise outer event
            tb.Leave += (sender, e) => SpecialTBLeave?.Invoke(this, e);
        }
    }
