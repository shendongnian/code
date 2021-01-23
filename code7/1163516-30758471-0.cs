        private void btns_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if(btn == btn1)
            {
                MessageBox.Show("Choice 1");
            }
            else if (btn == btn2)
            {
                MessageBox.Show("Choice 2");
            }
            else if (btn == btn3)
            {
                MessageBox.Show("Choice 3");
            }
        }
