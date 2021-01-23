    struct ThemeStyle
    {
        ThemeStyle(Color backColor, Color foreColor)
        {
            this.BackColor = backColor;
            this.ForeColor = foreColor;
        }
        public Color BackColor {get; private set;}
        public Color ForeColor {get; privatr set;}
        public void Apply(Control c)
        {
            c.BackColor = this.BackColor;
            switch(typeof(c))
            {
                 case typeof(TreeView):
                 case typeof(TextBox):
                   c.BorderStyle = this.BorderStyle;
                 break;
            }
        }
    }
