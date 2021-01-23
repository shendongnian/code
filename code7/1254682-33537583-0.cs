        private static bool closeFar(int a, int b, int c)
        {
            bool bIsNear = Math.Abs(a - b) <= 1;
            bool cIsNear = Math.Abs(a - c) <= 1;
            if (!(bIsNear^cIsNear))
            {
                return false;
            }
            int far = bIsNear ? c : b;
            return Math.Abs(far - a) >= 2 && Math.Abs(c - b) >= 2;
        }
