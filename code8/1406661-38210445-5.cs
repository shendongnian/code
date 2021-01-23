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
            //  a & b: Bitwise And
            //      Any bit that's "true" in both numbers is "true" in the result. 
            //      Any bit that's "false" in EITHER number is "false" in the result.
            //      11 & 11 == 11
            //      11 & 01 == 01
            //      11 & 10 == 10
            //      11 & 00 == 00
            //      01 & 11 == 01
            //      01 & 01 == 01
            //      01 & 10 == 00
            //      01 & 00 == 00
            //  So xx0011 -> 
            //      Pattern: 000011
            //      Mask:    001111
            //      Value    110011
            //  (110011 & 001111) == 000011
            //  (000011 & 001111) == 000011
            //
            //  000011 == 000011, so these two match. 
            return (value & Mask) == (Pattern & Mask);
        }
        public static int CompileMask(string patternString)
        {
            int mask = 0;
            int bitoffset = 0;
            //  For each character in patternString, set one bit in mask.
            //  Start with bit zero and move left one bit for each character.
            //  On x86, these bits are in reverse order to the characters in 
            //  the strings, but that doesn't matter. 
            foreach (var ch in patternString)
            {
                switch (ch)
                {
                    //  If the pattern has a '0' or a '0', we'll be examining that 
                    //  character in the value, so put a 1 at that spot in the mask.
                    case '1':
                    case '0':
                        //  a | b: Bitwise OR: If a bit is "true" in EITHER number, it's 
                        //  true in the result. So 0110 | 1000 == 1110.
                        //  a << b: Bitwise left shift: Take all the bits in a and move 
                        //  them leftward by 1 bit, so 0010 << 1 == 0100. 
                        //
                        //  So here we shift 1 to the left by some number of bits, and 
                        //  then set that bit in mask to 1. 
                        mask |= 1 << bitoffset;
                        break;
                    //  If it's an 'x', we'll ignore that character in the value by 
                    //  putting a 0 at that spot in the mask. 
                    //  All the bits are zero already.
                    case 'x':
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
            int bitoffset = 0;
            foreach (var ch in patternString)
            {
                //  For each character in patternString, set one bit in pattern.
                //  Start with bit zero and move left one bit for each character.
                switch (ch)
                {
                    //  If the pattern has a 1, require 1 in the result.
                    case '1':
                        pattern |= 1 << bitoffset;
                        break;
                    //  For 0, require 0 in the result.
                    case '0':
                        //  All the bits were zero already so don't waste time setting 
                        //  it to zero. 
                        break;
                    //  Doesn't matter what we do for 'x', since it'll be masked out. 
                    //  Just don't throw an exception on it. 
                    case 'x':
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
            int bitoffset = 0;
            //  For each character in patternString, set one bit in mask.
            //  Start with bit zero and move left one bit for each character.
            foreach (var ch in valueString)
            {
                switch (ch)
                {
                    //  If the value has a '1', have a 1 for that bit
                    case '1':
                        value |= 1 << bitoffset;
                        break;
                    //  If the value has a '0', leave a 0 for that bit
                    //  All the bits were zero already.
                    case '0':
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid pattern character: " + ch);
                }
                ++bitoffset;
            }
            return value;
        }
    }
