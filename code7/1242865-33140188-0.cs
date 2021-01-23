    public class MyForm:Form {
        MyForm(){
            uiComboBox.SelectedIndexChanged += uiComboBox_SelectedIndexChanged;
        }
        private void uiComboBox_SelectedIndexChanged(object sender, EventArgs e)       {
            customControl.InvokeSomeMethod(xxx);
        }
    }
