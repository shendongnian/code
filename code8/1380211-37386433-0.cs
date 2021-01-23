        public int sumofD(int n)
        {
            if (n == 0)
            { return 0; }
            else
            {
                return (n % 10 + sumofD(n / 10));
            }
        }
