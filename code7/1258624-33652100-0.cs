    private UC1 uc1 = new UC1() {
      Visible = false
    };
    
    private UC2 uc2 = new UC2() {
      Visible = false
    };
    
    private UC3 uc3 = new UC3() {
      Visible = false
    };
    
    private void Form1_Load(object sender, EventArgs e)
    {
       Controls.Add(uc1);
       Controls.Add(uc2); 
       Controls.Add(uc3);
    }
    
    private void button1_Click(object sender, EventArgs e) {
      uc1.Visible = true;
      uc2.Visible = false;
      uc3.Visible = false;
    }
    
    private void button2_Click(object sender, EventArgs e) {
      uc1.Visible = false;
      uc2.Visible = true;
      uc3.Visible = false;
    }
    
    private void button3_Click(object sender, EventArgs e) {
      uc1.Visible = false;
      uc2.Visible = false;
      uc3.Visible = true;
    }
