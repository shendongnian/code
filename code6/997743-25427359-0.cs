    public virtual void onMessage(MQ.Message Message)
    {
       MQ.TextMessage txtMessage = (MQ.TextMessage)Message;
       String MsgBody = txtMessage.getMessage();
    
       Program.myForm.Invoke(delegate()
       {
          Program.myForm.Text = MsgBody;
       });
    }
