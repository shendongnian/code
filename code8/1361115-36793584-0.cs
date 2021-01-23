    using System;
    class Player
    {
        string forename = "";
        string errorMessage = "";
        public string Forename
        {
            get
            {
                return forename;
            }
            set
            {
                bool okChar = OnlyChars(value, "Forename");
    
                if (okChar == true)
                    forename = value;
                else
                {
                    throw new NewException(errorMessage);
                }
            }
        }
    
        private bool OnlyChars(string value, string p)
        {
            if (value == p)
                return true;
            else
            {
                errorMessage = "Err";
                return false;
            }
    
        }
    }
    
    class NewException : Exception
    {
        private string messageM;
    
        public NewException()
            : base()
        {
        }
    
        public NewException(string message)
            : base(message)
        {
            messageM = message;
        }
    
        public string MessageM
        {
            get { return messageM; }
            set { messageM = value; }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var player1 = new Player();
                var player2 = new Player();
                player1.Forename = "asdfg";
                player2.Forename = "qwerty";
    
            }
            catch (NewException exc)
            {
                bool error = true;
            }
        }
    }
