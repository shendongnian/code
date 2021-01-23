    public partial class Form2 : Form
    {
      public Form2()
      {
        InitializeComponent();
      }
      
      public event EventHandler ButtonClicked;
      protected virtual void OnButtonClicked()
      {
        EventHandler handler = ButtonClicked;
        if (handler != null) handler(this, EventArgs.Empty);
      }
      private void button1_Click(object sender, EventArgs e)
      {
        OnButtonClicked();
        Close();
      }
    }
