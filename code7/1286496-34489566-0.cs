    public partial class Form2 : Form {
        public string InputText = ""; //use this to record whatever is inputed in the Form2 by the user
        //somewhere else in the code
        public void foo(){ //this may be closing event or button pressed event
            InputText = textBoxInForm2.Text; //record the input from `form2` textbox
            this.DialogResult = DialogResult.OK; //mark as ok
        }
    }
