    var pnl = new Panel();
    PictureBox picB = new PictureBox();
    Button btn1 = new Button();
    Button btn2 = new Button();
    picB.Size = new Size(130, 70);
    picB.BorderStyle = BorderStyle.Fixed3D;
    btn1.Text = "btn1";
    btn2.Text = "btn2";
    btn1.Hide();
    btn2.Hide();
    
    pnl.Controls.Add(btn1);
    pnl.Controls.Add(btn2);
    pnl.Controls.Add(picB);
    btn1.BringToFront();
    btn2.BringToFront();
    this.Controls.Add(pnl);
    // picturebox and Panlel both handle MouseEnter
    picB.MouseEnter += picAndpnl_MouseEnter;
    pnl.MouseEnter += picAndpnl_MouseEnter;
    pnl.MouseLeave += picB_MouseLeave;
    btn1.MouseClick += btn1_MouseClick;
    btn2.MouseClick += btn2_MouseClick;
 
