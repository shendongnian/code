    class Calculate(){
        private boolean lastGoodValueSet = false;
        private int lastGoodValue = 0;
        
        void buttonFunction(){
            if (myButton.Content.ToString() == "=")
            {
                //Your code
                try
                {
                    var v = dt.Compute(s, "");
                    tbkSum.Text = s + "=" + v.ToString();
                    lastGoodValue = v;
                    lastGoodValueSet = true;
                }
    
                catch
                {   
                    MessageBox.Show("Invalid Sum");
                    tbxSum.Text = result;
                    if (lastGoodValueSet)
                        tbxSum.Text = lastGoodValue;
                }
            }
        }
    
    }
