     private void bntOK_Click(object sender, EventArgs e)
        {
            int cnt10, ntEQ;
            cnt10 = 10;
            string id = null;  
            string dsp = txtInput.Text.Trim(' '); 
            
            int rs = string.Compare(dsp, "9");
            if (rs == 0)
            {
                id = string.Format("123-000000{00}-A12", cnt10);
                txtResult.Text = id; 
            }
            
            else 
            {
                int dspt = Convert.ToInt16(txtInput.Text.Trim());
                ntEQ = dspt + 1;
                id = string.Format("123-000000{00}-A12", ntEQ);
                txtResult.Text = id;
            }
           
        }
