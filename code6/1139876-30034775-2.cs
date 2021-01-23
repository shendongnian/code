        private string[] _Things;
        public string[] Things
        {
            get
            {
                if (_Things == null)
                {
                    _Things = new string[] { "First Thing", "Second Thing" };
                }
                return _Things;
            }
        }
