        private void btnConnect(object sender, EventArgs e)
        {
            MessageQueue myMQ = new MessageQueue();
            //Register handler
            myMQ.MsgTrigger += new EventHandler(passMessage);
            myMQ.Connect(...);
        }
