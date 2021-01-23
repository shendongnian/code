    private void button1_Click(object sender, EventArgs e)
    {
         this.SuspendLayout();
         panel1.Visible = true;
         panel2.Visible = false;
         this.ResumeLayout();
         //Application.DoEvents();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
         this.SuspendLayout();
         panel2.Visible = true;
         panel1.Visible = false;
         this.ResumeLayout();
         //Application.DoEvents();
    }
