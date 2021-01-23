        public static List<List<string>> GetSplitedValues(IList<string> _inputList )
        {
            
            string[] splitwords = _inputList[0].Split('-');
            List<string>[] _ouputList = new List<string>[splitwords.Length];
            for(int i=0;i<_ouputList.Length;i++)
            {
                _ouputList[i]=new List<string>();
            }
            for (int i = 0; i < _inputList.Count; i++)
            {
                string[] _splitwords = _inputList[i].Split('-');
                for (int j = 0; j < splitwords.Length; j++)
                {
                    _ouputList[j].Add(_splitwords[j]);
                }
            }
            List<List<string> >_temp= new List<List<string>>();
            _temp.AddRange(_ouputList);
            return _temp;
        }
