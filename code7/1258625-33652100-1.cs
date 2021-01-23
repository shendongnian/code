    private UC1 uc1 = new UC1() {
      Visible = false
    };
    
    private UC2 uc2 = new UC2() {
      Visible = false
    };
    
    private UC3 uc3 = new UC3() {
      Visible = false
    };
    
    private void VisualizeUC(Control value) {
      uc1.Visible = false;
      uc2.Visible = false;
      uc3.Visible = false;
      value.Visible = true; 
    } 
    private void Form1_Load(object sender, EventArgs e) {
      Controls.Add(uc1);
      Controls.Add(uc2); 
      Controls.Add(uc3);
    }
    
    private void button1_Click(object sender, EventArgs e) {
      VisualizeUC(uc1);
    }
    
    private void button2_Click(object sender, EventArgs e) {
      VisualizeUC(uc2);
    }
    
    private void button3_Click(object sender, EventArgs e) {
      VisualizeUC(uc3);
    }
