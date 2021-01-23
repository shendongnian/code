    class Meme
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public bool Popular { get; set; }
        public string Identifier { get; set; }
        public bool Equals(object other)
        {
            var casted = other as Meme;
            if(null == casted)
            {
                 return false;
            }
            return casted.Name == Name && Casted.Topic == Topic and Casted.Popular == Popular && Casted.Identifier == Identifier;
        }
    }
