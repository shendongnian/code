    public class Item : Dictionary<Type. float>
    {
        public float this[Type index]
        {
            get
            {
                if (ContainsKey(index)
                    return base[index];
                return 0f;
            }
            set
            {
                Add(index, value);
            }
        }
    }
