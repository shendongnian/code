         public static int i = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            var childForm = new ChildWindow();          
            childForm.Show();
        }
        private void Parent_FormClosing(object sender, FormClosingEventArgs e)
        {           
            if (i==1 || i==4)
            {              
                Application.Exit();
            }
            
            if (i == 2)
            { 
                ChildWindow.i= 3;
            }            
        }
