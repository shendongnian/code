    class Program
    {
        private void Test(object inputs)
        {
            if (inputs is List<TypeA>)
                loop((List<TypeA>) inputs);
            if (inputs is List<TypeB>)
                loop((List<TypeB>)inputs);
        }
        private void loop(IEnumerable<TypeA> inputs)
        {
            foreach (var input in inputs)
            {
                logic(input.i);
            }
        }
        private void loop(IEnumerable<TypeB> inputs)
        {
            foreach (var input in inputs)
            {
                logic(input.i);
            }
        }
        private void logic(int i)
        {
            // magic happens here
        }
    }
    class TypeA
    {
        public int i;
    }
    class TypeB
    {
        public int i;
    }
