        public void Add(string location)
        {
            PhotoElement pe = new PhotoElement(location);
            BaseAdd(pe);
        }
        public void Remove(string location)
        {
            BaseRemove(location);
        }
