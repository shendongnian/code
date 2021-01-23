        class newclass
        {
            private static int MyVarValue = 0;
            public static int MyVar
            {
                get;
                set
                {
                    MyVarValue = Convert.ToInt32(value);
                }
            }
        }
