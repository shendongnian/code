       private bool isEvenClick;
       private void button1_Click(object sender, EventArgs e)
        {
            if (!isEvenClick)
            {
                m1();
                isEvenClick = true;
            }
            else
            {
                m2();
                isEvenClick = false;
            }
        }
        public void m1()
        {
            button1.Text = "01";
        }
        public void m2()
        {
            button1.Text = "02";
        }
