    private bool IfTextBoxEmpty(string text, string message, Control control)
        {
            if (text == "")
            {
                MessageBox.Show(message);
                this.ActiveControl = control;
                return true;
            }
            return false;
        }
