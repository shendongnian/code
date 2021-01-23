    public class PatternMatcher
    {
        public PatternMatcher(String pattern)
        {
            Pattern = CompilePattern(pattern);
            Mask = CompileMask(pattern);
        }
        #region Fields
        //  Could we save any cycles by making these fields instead of properties? 
        //  I think the optimizer is smarter than that. 
        public int Pattern { get; private set; }
        public int Mask { get; private set; }
        #endregion Fields
        public bool CheckValue(String value)
        {
            return CheckValue(CompileValue(value));
        }
        public bool CheckValue(int value)
        {
            return (value & Mask) == (Pattern & Mask);
        }
        public static int CompileMask(string patternString)
        {
            int mask = 0;
            int bitoffset = 1;
            foreach (var ch in patternString)
            {
                switch (ch)
                {
                    case '1':
                    case '0':
                        mask &= 1 << bitoffset;
                        break;
                    case 'x':
                        //  All the bits are zero already.
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid pattern character: " + ch);
                }
                ++bitoffset;
            }
            return mask;
        }
        public static int CompilePattern(string patternString)
        {
            int pattern = 0;
            int bitoffset = 1;
            foreach (var ch in patternString)
            {
                switch (ch)
                {
                    case '1':
                        pattern &= 1 << bitoffset;
                        break;
                    case 'x':
                        //  Doesn't matter what we do for 'x', since it'll be masked out. 
                        //  Just don't throw an exception. 
                    case '0':
                        //  All the bits are zero already.
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid pattern character: " + ch);
                }
                ++bitoffset;
            }
            return pattern;
        }
        public static int CompileValue(string valueString)
        {
            int value = 0;
            int bitoffset = 1;
            foreach (var ch in valueString)
            {
                switch (ch)
                {
                    case '1':
                        value &= 1 << bitoffset;
                        break;
                    case '0':
                        //  All the bits are zero already.
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid pattern character: " + ch);
                }
                ++bitoffset;
            }
            return value;
        }
    }
