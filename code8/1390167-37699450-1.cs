        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (textBox1.ContainsFocus || textBox2.ContainsFocus || textBox3.ContainsFocus)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (keyData == Keys.Delete)
            {
                removeRect();
                return true;
            }
            else if (keyData == Keys.Left)
            {
                previousImg();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                nextImg();
                return true;
            }
            
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
