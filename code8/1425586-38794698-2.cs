    // File: MyFormBase.cs
    public partial class MyFormBase : Form
    {
        public MyFormBase()
            : base()
        {
            Icon = Properties.Resources.bar;
        }
    }
 
    // In your Form file:
    public partial class MyForm : MyFormBase
    {
        // ...
    }
