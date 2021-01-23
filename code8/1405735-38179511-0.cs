    public class FormWithListBox
    {
        private void openFormWithButton()
        {
            var formWithButton = new FormWithButton(this);
            formWithButton.Show();
        }
        public void addList(string sName)
        {
            listBox.Items.Add(...);
        }
    }
    
    public class FormWithButton
    {
        private readonly FormWithListBox _form;
        public FormWithButton(FormWithListBox form)
        {
            _form = form;
        }
    
        public void bAdd_Click(object sender, RoutedEventArgs e)
        {
            _form.addList("...BlaBlaBla...");
        }
    }
