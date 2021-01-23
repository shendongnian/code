        public static  void Enable(List<object> ctrs, bool enable)
        {
            foreach (var ctr in ctrs)
            {
                dynamic a=ctr;
                a.Enabled = enable;
            }
        }
