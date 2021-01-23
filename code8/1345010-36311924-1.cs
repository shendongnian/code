    class SomeClass
    {
    private string path;
    .....
    private void nacitanie_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Otvoriť Textový súbor.";
            dialog.Filter = "TXT files|*.txt";
            dialog.InitialDirectory = @"C:\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
            }
        }
    ....
    }
