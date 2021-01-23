        static string DrawX(int spaces, int x)
        {
            char[] chrarr = new char[spaces + x];
            for (int i = 0; i < spaces; i++)
            {
                chrarr[i] = '_';
            }
            for (int i = spaces - 1; i < chrarr.Length - spaces; i++)
            {
                chrarr[i] = 'X';
            }
            return new string(chrarr);
        }
