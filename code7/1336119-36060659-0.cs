    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    Microsoft.Office.Interop.Word.Application word;
    private void button1_Click(object sender, EventArgs e)
    {
        word = new Microsoft.Office.Interop.Word.Application();
        var documents = word.Documents;
        documents.Open(@"d:\file1.docx");
        SetParent(new IntPtr(word.ActiveWindow.Hwnd), this.Handle);
        word.Visible = true;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (word != null)
            word.Quit();
    }
