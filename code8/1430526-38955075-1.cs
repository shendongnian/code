    class Derived : Base<Derived>, ISource
    {
        public string GetSource()
        {
            return "This specific source";
        }
    }
