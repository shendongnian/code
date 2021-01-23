    public partial class Form2 : Form {
        public string InputText = ""; //use this to record whatever is inputed in the Form2 by the user
        //somewhere else in the code
        public void foo(){ //this may be closing event or button pressed event
            InputText = textBoxInForm2.Text; //record the input from `form2` textbox
            this.DialogResult = DialogResult.OK; //mark as ok
        }
        //This is exactly the foo above, but just in case you wonder how the event FormClosing look like:
        //Add this event handler on your Form2
		private void Form2_FormClosing(object sender, FormClosingEventArgs e) {
            InputText = textBoxInForm2.Text; //record the input from `form2` textbox
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
    }
