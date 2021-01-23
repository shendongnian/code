    private void OnChanged(object source, FileSystemEventArgs e)
    {
        Invoke((MethodInvoker)delegate
        {
              string usedPath = Path.Combine(Directory.GetCurrentDirectory(), "usedwords.txt");
              richTextBox2.LoadFile(usedPath, RichTextBoxStreamType.PlainText);      
        });
    }
