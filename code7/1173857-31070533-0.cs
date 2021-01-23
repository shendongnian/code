        public void AddOrUpdateDictionary(string key, string value)
        {
            if (this.MyContent.ContainsKey(key))
            {
                this.MyContent[key] = string.Concat(this.MyContent[key], value);
            }
            else
            {
                this.MyContent.AddOrUpdate(key, value, (x, y) => value);
            }
        }
