        private static int _judgeResult;
        private static int JudgeResult
        {
            get
            {
                return _judgeResult;
            }
            set
            {
                _judgeResult = value;
                if (MaxResult < value)
                    MaxResult = value;
            }
        }
        private static int _maxresult;
        private static int MaxResult
        {
            get
            {
                return _maxresult;
            }
            set
            {
                _maxresult = value;
            }
        }
