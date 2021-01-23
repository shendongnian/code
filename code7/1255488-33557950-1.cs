        public static int _judgeresult;
        private static int judgeResult
        {
            get { return _judgeresult; }
            set {
                _judgeresult = value;
                if (value > MaxValue)
                    MaxValue = value;
            }
        }
        private static int MaxValue { get; set; }
