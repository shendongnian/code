    public class Extensions
    {
         public MethodA(this TextBox tb)
         {
             tb.Text = (Convert.ToInt32(tb.Text) + 5).ToString();
         }
    }
