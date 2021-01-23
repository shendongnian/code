    Public class Form2 : Form
    {
      public Form1 frm1 = null;
      public Form2(Form1 frm)
      {
        this.frm1 = frm;
      }
    
     protected void btn_click(object sender, EventArgs e)
    {
      frm1.Plottingmethod();
    }
    } 
