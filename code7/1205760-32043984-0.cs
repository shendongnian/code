     public class CallbackHandler 
        {
            public TextBox textValue { get; set; }
    
            CallbackHandler(TextBox tb) {
    
                this.textValue = tb;
               
            }
            public void SendMessageToClients(Message m)
            {
                this.textValue.Text="some_message";
                //I would like to call an alrdy generated textbox here to set its value, like txtMessageAll.Text("Setting text");
            }
        }
