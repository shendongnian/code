    public partial class MainForm : Form
    {
      bool isOn = false;
      public MainForm()
      {
         InitializeComponent();
         pnlInner.BackColor = Color.LightGoldenrodYellow;
         pnlOuter.BackColor = Color.LightGoldenrodYellow;
      }
      private void ToggleColor_Click(object sender, EventArgs e)
      {
         if (isOn)
         {
            pnlOuter.BackColor = Color.LightGoldenrodYellow;
            isOn = false;
         }
         else
         {
            pnlOuter.BackColor = Color.Red;
            isOn = true;
         }
      }
    }
