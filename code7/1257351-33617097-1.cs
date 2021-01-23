            private void button_Click(object sender, EventArgs e)
            {
               if(this.Controls.Contains(this.userControl1))
                     this.Controls.Remove(this.userControl1);
               if(!this.Controls.Contains(this.userControl2))
                this.Control.Add(this.userControl2);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if(!this.Controls.Contains(this.userControl1))
                     this.Control.Add(this.userControl1);
               if(this.Controls.Contains(this.userControl2))
                    this.Controls.Remove(this.userControl2);
            }
