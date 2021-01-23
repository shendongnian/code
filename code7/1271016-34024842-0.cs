    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
        button1.MouseEnter += OnMouseEnterButton1;
        button1.MouseLeave += OnMouseLeaveButton1;
      }
      
      private void OnMouseEnterButton1(object sender, EventArgs e)
      {
        button1.BackColor = SystemColors.ButtonHighlight; // or Color.Red or whatever you want
      }
      private void OnMouseLeaveButton1(object sender, EventArgs e)
      {
        button1.BackColor = SystemColors.ButtonFace;
      }
    }
