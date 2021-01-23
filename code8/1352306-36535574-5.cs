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
        //IMPORTANT: The Equals and the GetHashCode methods are intertwined. Thus, when you override one of them, you should override the other.
        //The rule is: The GetHashCode method should return the same value for two objects that are equals (according to their Equals method)
        //More about the GetHashCode method: https://msdn.microsoft.com/en-us/library/system.object.gethashcode%28v=vs.110%29.aspx
        public int GetHashCode()
        {
            //Naive implementation
            return Name.GetHashCode();
        }
    }
