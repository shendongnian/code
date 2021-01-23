    public class MyTextBox: TextBox
    {
      public MyTextBox()
      {
        Text = "Hi";
      }
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
