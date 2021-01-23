    class Form1
    {
        private void onShowForm2()
        {
            Form2 f2 = new Form2();
            f2.MainForm = this;
            f2.Show();
        }
    }
    
    class Form2
    {
        public Form1 MainForm { get; set; }
        private void DoStuff()
        {
            //Change selected index on passed in instance of Form1
            MainForm.tbControl.SelectedIndex=1;
        }
    }
