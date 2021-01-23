        public class RangeInfo
        {
            private string _text;
            private int[] _range;
            public int[] Range
            {
                set
                {
                    if (value.Length != 2)
                        throw new Exception("Length must be 2.");
                    if (_range == null)
                        _range = new int[2];
                        
                    _range[0] = value[0];
                    _range[1] = value[1];
                }
                get
                {
                    return _range;
                }
            }
            public string Text { set { _text = value; } get { return _text; } }
        }
        public readonly RangeInfo[] Ranges = new RangeInfo[4] { 
                        new RangeInfo { Range = new int[] {Int32.MinValue,70}, Text = "..." },
                        new RangeInfo { Range = new int[] {70,80}, Text = "..." },
                        new RangeInfo { Range = new int[] {80,90}, Text = "..."},
                        new RangeInfo { Range = new int[] {90,Int32.MaxValue}, Text = "..." }
                };
