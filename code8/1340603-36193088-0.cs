    public struct ParseResponse
    {
        public bool output;
        public byte response;
    }
    class ParseOptions
    {
        Func<Message, ParseResponse>[] options = null;
        public ParseOptions()
        {
            options = new Func<Message, ParseResponse>[]{
                ParseMessageOptionOne,
                ParseMessageOptionTwo,
                ParseMessageOptionThree
            };
        }
        public void IncomingMessageSwitchStatements(Message msg, Host host)
        {            
            byte someByte = 2;
            var response = options[someByte](msg);
            if (response.output && response.response == 0x01)
            {
                //UpdateUiFromHere();
            }
        }
        private ParseResponse ParseMessageOptionThree(Message msg)
        {
            return new ParseResponse { output = true };
        }
     }
