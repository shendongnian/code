    public class MetroButton : System.Windows.Forms.Button
    {
        private bool highlight;
        public bool Highlight
        { 
            get
            {
                return highlight;
            }
            set
            {
                highlight = value;
                if (highlight)//This is the same as "if(highlight == true)" but the last part is redundant in most programming languages.
                {
                    FlatAppearance.BorderColor = Color.Gray;
                    FlatAppearance.BorderSize = 2;
                    FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                }
                else 
                {
                    base.FlatAppearance.BorderColor = Color.FromArgb(0, 174, 219);
                    base.FlatAppearance.BorderSize = 3;
                    base.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                }
            }
        }
        public MetroButton()
        {
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            Highlight = true;//Just setting a default.
        }
    }
