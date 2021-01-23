        private void button1_Click(object sender, EventArgs e)
        {            
            count++;   //increment the variable on every button click that is declared globally 
            if(count%2==0)//checking the condition
                m2();//calling the method if the condition is true
            else  m1(); //else calling another method
            
        }
        public void m1()//method1
        { button1.Text = "01";}      
        public void m2()//method2
        {button1.Text = "02";}
            
    }
