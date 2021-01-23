       static void Main()
        {
            //stand-in for my database
            var options = new byte[] { 1, 2, 3, 3, 2, 2, 3, 4, 2, 2, 1,5 };
            var input = (Options)5;
            //input broken down into a list of individual flags
            var optional = GetFlags(input).ToList();
            //get just the options that match either of the flags (but not the combo flags, see below)
            var foundOptions = options.Where(x => optional.Contains((Options)x)).ToList();
            //foundOptions will have 3 options: 1,4,1
        }
        static IEnumerable<Enum> GetFlags(Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }
