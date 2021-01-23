    public bool cetakTanya(string message)
    {
        var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        return result == DialogResult.Yes;
    }
