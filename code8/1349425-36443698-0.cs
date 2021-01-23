    public class FindReplaceForm
    {
        private Form1 formToControl = null;
        public FindReplaceForm(Form1 formToControl)
        {
            this.formToControl = formToControl;
        }
        private void OnButton1_Click(...)
        {
            this.formToControl.TextBox_Value_Text.SelectedText = ...
        }
