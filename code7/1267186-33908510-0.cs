        public static string MyFormat(string str, params object[] args)
        {
            int count = args.Length;
            for (int i = 1; i < count; i++)
            {
                if (args[i].GetType() == typeof(string))
                    args[i] = "'" + args[i] + "'";
            }
            return string.Format(str, args);
        }
