    public class Form_Main : Form
    {
        public List<string> folderList; //<---- i want to access this.....
        private void button_showForm2_Click(object sender, EventArgs e)
        {
            Form_Log ConfirmBoxForm = new Form_Log(this);
            ConfirmBoxForm.Show();
        }
    }
