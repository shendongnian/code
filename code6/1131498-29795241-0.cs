    class Counter
    {
        public int[] Radices;
        public int[] this[int n]
        {
            get 
            { 
                int[] v = new int[Radices.Length];
                int i = Radices.Length - 1;
                while (n != 0 && i >= 0)
                {
                    //Hope C-kiddy-# have IL-opcode for div-and-reminder like x86 do
                    v[i] = n % Radices[i];
                    n /= Radices[i--];
                }
                return v;
            }
        }
    }
