    public class Form2 : Form
    {
        private MainForm mainForm;
        public Form2(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public void SomeMethodThatUpdatesFileNamesList()
        {
            mainForm.filenamesList.Clear();
            ...
        }
    }
