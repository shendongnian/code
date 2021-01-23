    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TextBox someTextBox = new TextBox();
            someTextBox.PreviewKeyDown += someTextBox_PreviewKeyDown;
            Form myMainWindow = new Form();
            myMainWindow.Controls.Add(someTextBox);
            Application.Run(myMainWindow);
        }
        static void someTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.L && (e.Control))
            {
                MessageBox.Show("You can choose from four different languages by clicking on the radio buttons");
            }
            else if (e.KeyCode == Keys.A && (e.Shift))
            {
                MessageBox.Show("This is version 1.0");
            }
        }
    }
