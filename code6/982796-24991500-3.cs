    public abstract class FormBase : Form
    {
         public FormBase()
         {
              // Constructor code
              this.Name = this.GetType().Name;
         }
    }
    public class myFrvForm : Form
    {
         public myFrvForm() // base constructor will set name of the form to appropriate one
         {
         }
    }
