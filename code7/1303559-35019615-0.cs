        protected void NotifyAllPropertiesChanged<T>()
        {
            foreach (var p in this.GetType().GetProperties())
                if (p.PropertyType == typeof(T))
                    OnPropertyChanged(p.Name);
        }
