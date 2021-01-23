    public string GetFormattedString(double val)
            {
                string newVal;
                if (rblFtmp1.Text == DOLLAR)
                {
                    newVal = String.Format("{0:0.00}", val);
                }
                else // If not DOLLAR then it's PERCENT
                {
                    newVal = String.Format("{0:0.000}", val);
                }
                return newVal;
            }
