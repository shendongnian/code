        public void OnMouseDown(object sender, MouseEventArgs e)
        { 
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Do some stuff
                MessageBox.Show("Lefty!");
            }
            else if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Do some stuff
                MessageBox.Show("Righty!");
            }
        }
