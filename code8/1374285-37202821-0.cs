    List<Control> allBoxes = null ; 
    public Form1()
    {
      InitializeComponent();
      allBoxes = new List<Control>() { textBox1, textBox2, label1..};
      foreach (Control ctl in allBoxes) ctl.Tag = "";  // initialize..
      textBox1.Tag =  " 1 2 3 4 5 6 8 9 10 "
      textBox2.Tag =  " 3 4 5 6 8 9 10 "
      textBox3.Tag =  " 5 6 8 9 10 "
      textBoxXYZ.Tag =  " 1  3 7 5 10 "
   }
    void SetVisibility(int value)
    {
         foreach (Control ctl in allBoxes) 
           ctl.Visible = ctl.Tag.ToString().Contains(value.ToString(" #0 "));
    }
