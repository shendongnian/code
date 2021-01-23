    public class Entity
    {
        public Entity()
        {
            EntityPropertyDic = new Dictionary<string, object>();
        }
        public object this[string propertyName]
        {
            get
            {
                if (EntityPropertyDic.ContainsKey(propertyName))
                {
                    return EntityPropertyDic[propertyName];
                }
                else
                    throw new ArgumentException("PropertyName Is not exist!");
            }
            set
            {
                OnColumnChanging(propertyName, ref value);
                EntityPropertyDic[propertyName] = value;
            }
        }
        private void OnColumnChanging(string propertyName, ref object value)
        {
            throw new NotImplementedException();
        }
        protected Dictionary<string, object> EntityPropertyDic { get; set; }
    }
