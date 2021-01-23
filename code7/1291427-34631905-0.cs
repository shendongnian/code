    public class MyTextBox: TextBox
    {
      [DefaultValue("Hi")]
      public new string Text 
      { 
        get
        {
           return base.Text;
        }
        set
        { 
           base.Text = value;
        }
    
    }
