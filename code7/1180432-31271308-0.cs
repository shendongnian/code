    void ChatServer_OnDataReceived(object sender, ReceivedArguments e)
        {
            string machine = e.Name;
            string message = e.ReceivedData;
            popupNotification.TitleText = "New  message";
            popupNotification.ContentText = machine + " sent a message at " + DateTime.Now.ToShortTimeString() +
                ", saying  \"" + message + "\"";
            popupMethod(); //call the method that works cross-thread
            changeTextBoxContents(e.Name + " sent a message at " + DateTime.Now.ToShortTimeString() +
                ", saying  \"" + e.ReceivedData + "\"");
        }
    ///This method works cross thread by checking if an invoke is required
    ///and if so, then the popup is shown with a delegate across the thread
    void popupMethod()
        {
            if(InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    popupNotification.Popup();
                }));
                return;
            }
        }
