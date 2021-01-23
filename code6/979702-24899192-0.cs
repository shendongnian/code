    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
      protected override void OnValidating(CancelEventArgs e) {
        e.Cancel = (textBox1.Text.Trim() == String.Empty);
        base.OnValidating(e);
      }
    }
