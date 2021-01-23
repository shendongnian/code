    public class MenuCollection : ConfigurationElementCollection
      {
        public MenuCollection()
        {
          Console.WriteLineMenuCollection Constructor");
        }
    
        public MenuConfig this[int index]
        {
          get { return (MenuConfig)BaseGet(index); }
          set
          {
            if (BaseGet(index) != null)
            {
              BaseRemoveAt(index);
            }
            BaseAdd(index, value);
          }
        }
    
        public void Add(MenuConfig menuConfig)
        {
          BaseAdd(menuConfig);
        }
    
        public void Clear()
        {
          BaseClear();
        }
    
        protected override ConfigurationElement CreateNewElement()
        {
          return new MenuConfig();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
          return ((MenuConfig) element).Port;
        }
    
        public void Remove(MenuConfig menuConfig)
        {
          BaseRemove(menuConfig.Port);
        }
    
        public void RemoveAt(int index)
        {
          BaseRemoveAt(index);
        }
    
        public void Remove(string name)
        {
          BaseRemove(name);
        }
      }
