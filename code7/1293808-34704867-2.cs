    class ComboBoxViewItem<T>
    {
        public string Name;
        public int ID;
        public T Item { get; set; }
    
        public ComboBoxViewItem(T item, string name, int id)
        {
            this.Item = item;
            this.Name = name;
            this.ID = id;
        }
    
        public ComboBoxViewItem(T item)
        {
            var prop = item.GetType().GetProperty("Name");
            if (prop == null)
                throw new ArgumentException("This object does not have ...");
            if (prop.PropertyType != typeof(string))
                throw new ArgumentException("The property Name MUST be of type...");
            this.Name = (string)prop.GetValue(item);
            prop = item.GetType().GetProperty("ID");
            if (prop == null)
                throw new ArgumentException("This object does not have ...");
            if (prop.PropertyType != typeof(int))
                throw new ArgumentException("The property ID MUST be of ...");
            this.ID = (int)prop.GetValue(item);
            this.Item = item;
        }
        public override string ToString()
        {
            // C# 6.0 string interpolation
            //return string.Format($"{ID}, ({Name})");
            // C# Standard string formatting
            return string.Format("{0}, ({1})", ID, Name);
        }
    }
