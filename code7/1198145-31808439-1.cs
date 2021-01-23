        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> postParameters = null;
            byte[] param1 = null;
            DataSelector.SelectedIndexChanged += (ss, ee) =>
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
            };
            button1.Click += (ss, ee) =>
            {
                postParameters = new Dictionary<string, object>();
                postParameters.Add("param1", param1);
            };
        }
