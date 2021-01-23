    public class Professor
    {
        ...
        private static Professor _default;
        public static Professor Default
        {
            get
            {
                if (_default == null)
                    _default = new Professor(-1, "John", "Smith");
                return _default;
            }
        }
    }
