        public static string UpperOrLower(string mj)
        {
            if (string.IsNullOrEmpty(mj))
            {
                if (char.IsUpper(mj[0]))
                {
                    mj = "upper";
                }
                else mj = "lower";
            }
            else
            {
                mj = "empty";
            }
            return mj;
        }
