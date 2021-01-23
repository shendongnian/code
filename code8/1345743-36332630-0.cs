        private Dictionary<string,int> _dictn = new Dictionary<string,int>();
        public void Add_Update_ToDictn(string key, int id)
        {
            if (_dictn.ContainsKey(key))
            {
                _dictn[key] = id;
            }
            else
            {
                _dictn.Add(key, id);
            }           
        }
