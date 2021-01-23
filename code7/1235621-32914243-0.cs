        public static string UpperOrLower(string mj)
        {
            if (mj.Length > 0)
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
