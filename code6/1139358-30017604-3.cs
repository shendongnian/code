        // In the already started spirit of message box debugging ;-)
        MessageBox.Show("InvokeDisplayMessage Called");
        this._syncContext.Post(
            new SendOrPostCallback(x => DisplayMessage(message, name, nameColor)), 
            null);
    }
    </pre>
