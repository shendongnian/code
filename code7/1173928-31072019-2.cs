    class Program {
        [System.STAThread]
        static void Main(string[] args) {
            System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog();
            openDialog.Filter = "Cursor (*.cur)|*.cur";
            switch(openDialog.ShowDialog()) {
                case System.Windows.Forms.DialogResult.OK:
                    System.Windows.Forms.Cursor cursor = new System.Windows.Forms.Cursor(openDialog.FileName);
                    System.Windows.Forms.Form mainForm = new System.Windows.Forms.Form();
                    mainForm.Cursor = cursor;
                    System.Windows.Forms.Application.Run(mainForm);
                    break;
            }
        }
    }
