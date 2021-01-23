    private void loadComboEmail()
    {
        string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath); //seems to be the same to me, but is safer
        string build = System.IO.Path.Combine(path, "email.txt"); //much more safer then simple string addition
        string[] lines = System.IO.File.ReadAllLines(build);
        comboEmail.Items.AddRange(lines);
        comboEmail.SelectedIndex = 0;
    }
