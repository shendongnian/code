    static void OnNewMessage(object sender, S22.Xmpp.Im.MessageEventArgs e)
    {
        var invokingForm = Application.OpenForms[0]; // or whatever Form you can access
        if (invokingForm.InvokeRequired)
        {
            invokingForm.BeginInvoke(new EventHandler<S22.Xmpp.Im.MessageEventArgs>(OnNewMessage), sender, e);
            return; // important!!!
        }
        // the rest of your code goes here, now running
        // on the same ui thread as invokingForm
    }
        
