    // Form1.Designer.cs
    partial class Form1
    {
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        
        // ...
    }
    
    // Form with menu
    public partial class Form1 : Form
    {
        public void UpdateMenuStatus ( bool bEnable )
        {
            // update menu status here
        }
    }
    
    // Form that wants to update the menu on Form1
    public partial class Form2 : Form
    {
        private void SomeFunc ()
        {
            Form1 form1 = GetForm1Reference ();
            
            form1.UpdateMenuStatus ( true );
        }
    }
