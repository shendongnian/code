        static stub = new Item() { text = "NaN", id = -1 };
        public static Item get(int i)
        {
            Item result;
            result = data.FirstOrDefault(f => f.id == i);
    
            if (result == null)
            {
                return stub;
            }
    
            return result;
        }
