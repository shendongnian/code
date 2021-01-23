    void NotifyManager_Event(object sender, NotifyEventArgs e)
    {
        if(e.Type == MessageType.MessageBox && this == Form.ActiveForm)
            MessageBox.Show(this, e.Message);
        else
            statusBar.Text = e.Message;
    }
