    class YourClass
    {
        private int yes = 1;
        private int no = 0;
    
        private void BtnYes_Click(object sender, EventArgs e)
        {
            //Remove the type declaration here to use the class field instead. If you leave the type declaration, the variable here will be used instead of the class field.
            yes = 1;
            no = 0;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) 
        {
            if (yes == 1) {
            //EVENT
            }
        }
    }
