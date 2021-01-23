        private void button1_Click(object sender, EventArgs e)
        {            
            count++;
            if(count%2==0)
                m2();
            else  m1(); 
            
        }
        public void m1()
        { button1.Text = "01";}      
        public void m2()
        {button1.Text = "02";}
            
    }
