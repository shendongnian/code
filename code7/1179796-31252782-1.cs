    struct ThemeStyle
    {
        ThemeStyle(Color backColor, Color foreColor, BorderStyle borderStyle)
        {
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            this.BorderStyle = borderStyle;
        }
        public Color BackColor {get; private set;}
        public Color ForeColor {get; private set;}
        public BorderStyle BorderStyle {get; private set;}
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
