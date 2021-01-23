        static char[] ParseCharSequence(string s)
        {
            s = s.Trim();
            if (s.Length > 1 && s[0] == '[' && s[s.Length - 1] == ']')
            {
                char[] array = new char[s.Length / 2];
                int depositor = 0;
                int offset = -1;
                int boundary = s.Length - 1;
                for (int i = 1; i < boundary; i++)
                {
                    if (s[i] != ' ')
                    {
                        if (i == offset + 1)
                        {
                            throw new ArgumentException(String.Format("Conflict at index {0}.", i));
                        }
                        array[depositor++] = s[i];
                        offset = i;
                    }
                }
                Array.Resize(ref array, depositor);
                return array;
            }
            return null;
        }
