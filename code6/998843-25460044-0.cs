    client.Send(msg);
    taskbarNotifier3.CloseClick+=new EventHandler(CloseClick);
    taskbarNotifier3.Show("Email Successfully Sent!!!", "GOOB BYE!!!.", 500, 3000, 500);
    private void CloseClick(...)
    {
        this.Close();
    }
