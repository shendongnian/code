    public void InvokeDisplayMessage(string message, string name, Color nameColor)
    {
        // In the already started spirit of message box debugging ;-)
        MessageBox.Show("InvokeDisplayMessage Called");
        this.Dispatcher.BeginInvoke(new Action(delegate() {
            DisplayMessage(message, name, nameColor);
        }));
    }
