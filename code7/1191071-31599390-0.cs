        public IReadOnlyList<Entity> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = _items ?? new List<Entity>();
                if (value == null)
                    return;
                _items.AddRange(value);
            }
        }
