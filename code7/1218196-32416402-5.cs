    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    public class BaseN
    {
        List<char> CHARSET = null;
        public BaseN(string charset)
        {
            CHARSET = new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }
        public String ToBaseNString(BigInteger input)
        {
            var stack = new Stack<char>();
            while (input != 0)
            {
                stack.Push(CHARSET[(int)(input % CHARSET.Count)]);
                input /= CHARSET.Count;
            }
            return new string(stack.ToArray());
        }
        public BigInteger FromBaseNString(string input)
        {
            BigInteger sum = 0;
            int i = 0;
            foreach (char c in input.Reverse())
            {
                sum += CHARSET.IndexOf(c) * BigInteger.Pow(CHARSET.Count, i++);
            }
            return sum;
        }
    }
