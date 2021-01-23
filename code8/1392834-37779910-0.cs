    public class MyUserControl : UserControl
    {
      .
      .
      .
      public event EventHandler ButtonClick;
      .
      .
      .
      private void Button_Click(object sender, EventArgs e)
      {
         if (ButtonClick != null)
         {
            ButtonClick(sender, e);
         }
      }
    }
