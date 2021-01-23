    string path = Environment.ExpandEnvironmentVariables(@"%AppData%\Macromedia\"); // Example C:\Users\Mike\AppData\Roaming\Macromedia\ 
    if (Directory.Exists(path)) {
        string[] files = Directory.EnumerateFiles(path, "*FlashGame.sol", SearchOption.AllDirectories);
        foreach (string file in files) {
            try {
                File.Delete(file);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
