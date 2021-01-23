    public partial class GeneralInputForm : Form
    {
      private GeneralInputForm() // Private constructor
      {
        InitializeComponent();
      }
      public static bool TryGetValue<T>(
                 string label, 
                 string defaultValue, 
                 Func<T, bool> check, 
                 out T result
             ) where T : IConvertible
      {
        result = default(T);
        using (var frm = new GeneralInputForm())
        {
          frm.label1.Text = label;
          frm.textBox1.Text = defaultValue;
          frm.Closing += (o, e) =>
          {
            var myForm = (GeneralInputForm) o;
            // User closed not clicking the button?
            if (myForm.DialogResult != DialogResult.OK) 
              return;
            try
            {
              var checkval = (T) Convert.ChangeType(myForm.textBox1.Text, typeof (T));
              if (!check(checkval))
                e.Cancel = true;
            }
            catch
            {
              e.Cancel = true;
            }
            
          };
          if (frm.ShowDialog() == DialogResult.OK)
          {
            result = (T)Convert.ChangeType(frm.textBox1.Text, typeof (T));
            return true;
          }
        }
        return false;
      }
      private void button1_Click(object sender, EventArgs e)
      {
        // Don't use `Close()` on modal forms, it's always better to 
        // return a dialog result. This will close the form aswell
        DialogResult = DialogResult.OK; 
                                        
      }
    }
