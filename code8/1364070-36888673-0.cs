        public static List<string[]> split(string s)
        {
            bool ins = false;
            int no = 3;
            var L = new List<string>();
            var Res = new List<string[]>();
            var B = new StringBuilder();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '§':
                        if (ins)
                        {
                            ins = false;
                            L.Add(B.ToString());
                            if (no == 0)
                            {
                                Res.Add(L.ToArray<string>());
                                L.Clear();
                                no = 3;
                            }
                        }
                        else
                        {
                            ins = true;
                            B.Clear();
                        }
                        break;
                    case '|':
                        if (!ins) { no--; }
                        else B.Append(c);
                        break;
                    default:
                        if (ins) B.Append(c);
                        break;
                }
            }
            return Res;
        }
    }
