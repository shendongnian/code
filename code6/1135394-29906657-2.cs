    class Program
    {
        [Serializable]
        public abstract class Parser
        {
            public int GetData()
            {
                bool error = true;
                if (error)
                {
                    InvalidDataException exception = new InvalidDataException();
                    exception.Data.Add("owner", this);
                    throw exception;
                }
                return 0;
            }
    
            public abstract void handleError();
        }
        [Serializable]
        private class ParserA : Parser
        {
            public override void handleError()
            {
                Console.WriteLine("Handled in A");
            }
        }
        [Serializable]
        private class ParserB : Parser
        {
            public override void handleError()
            {
                Console.WriteLine("Handled in B");
            }
        }
        static void Main(String[] args)
        {
            try
            {
                int x = new ParserA().GetData();
                int y = new ParserB().GetData();
            }
            catch (InvalidDataException ex)
            {
                Parser parser = ex.Data["owner"] as Parser;
                if(parser != null)
                    parser.handleError();
            }
        }
    }
