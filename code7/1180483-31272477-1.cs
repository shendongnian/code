    public class LabelExtender3
    {
    
        private Label[] lblTemp = new Label[3];
        public bool Enabled
        {
            set
            {
                if (value)
                {
                    lblTemp[0].ForeColor = Color.MediumBlue;
                    lblTemp[1].ForeColor = Color.MediumBlue;
                    lblTemp[2].ForeColor = Color.MediumBlue;
                }
                else
                {
                    lblTemp[0].ForeColor = Color.SteelBlue;
                    lblTemp[1].ForeColor = Color.SteelBlue;
                    lblTemp[2].ForeColor = Color.SteelBlue;
                }
            }
        }
    
        public string SetText(int index, string value)
        {
            lblTemp[index].Text = value;
        }
    
        internal LabelExtender3(ref Label value1, ref Label value2, ref Label value3)
        {
            lblTemp[0] = value1;
            lblTemp[1] = value2;
            lblTemp[2] = value3;
        }
    }
