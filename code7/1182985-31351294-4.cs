    class Chainable
    {
        private readonly TextWriter _textWriter;
        public Chainable(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }
        public Chainable Write(BaseClass obj)
        {
            obj.SerializeTo(_textWriter);
            return this;
        }
    }
