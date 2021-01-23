        private Dictionary<string, object> postParameters = null;
        private byte[] param1 = null;
        private void DataSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DataSelector.SelectedIndex)
            {
                case 0:
                    param1 = new byte[] { 0x00, 0x01 };
                    //some code here 
                    break;
                case 1:
                    param1 = new byte[] { 0x00, 0x02 };
                    //some code here 
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            postParameters = new Dictionary<string, object>();
            postParameters.Add("param1", param1);
        }
