    //Decimal input UserControl
    public class decTextBox : TextBox
    {
        public string Text
        {
            get {
                return this.Text;
            }
        }
    
        public bool IsValid()
        {
            decimal n;
            bool isDecimal = decimal.TryParse(this.Text, out n);
            return isDecimal;
        }
    }
....
    public Control AutoCode(Control forEgTheForm)
    {
        //Tip: You may need to recursive call this function to check children controls are valid
        foreach(var ctrl in forEgTheForm.Controls) { 
            if(ctrl is TextBoxBase) {
                 if(ctrl is decTextBox) {
                     decTextBox txt = ((decTextBox)ctrl);
                     //If its not a valid value then set a[i]=true/false or in this example return the control...
                     if (!txt.IsValid()) return ctrl;
                 }
            }
        }
    }
