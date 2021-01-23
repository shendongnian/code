        public static String intToDatabaseIdentifier(int number)
        {
            const string abcFirst = "abcdefghijklmnopqrstuvwxyz";
            const string abcFull = "abcdefghijklmnopqrstuvwxyz0123456789";
            if (number < 0 || number > 1000000)
                throw new ArgumentOutOfRangeException("number");
            var stack = new Stack<char>();
            //Get first symbol. We will later reverse string. So last - will be first. 
            stack.Push(abcFirst[number % abcFirst.Length]);
            number = number / abcFirst.Length;
            //Collect remaining part
            while (number > 0)
            {
                int index = (number - 1) % abcFull.Length;
                stack.Push(abcFull[index]);
                number = (number - index) / abcFull.Length;
            }
            //Reversing to guarantee first non numeric.
            return new String(stack.Reverse().ToArray());
        }
