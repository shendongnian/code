    public class DNA
    {
        private Dictionary<string, FloatTrait> traits = new Dictionary<string, FloatTrait>() {
            {"Size", new FloatTrait(5.0)},
            {"Speed", new FloatTrait(50.0)},
        }
    
        public DNA(Dictionary<string, FloatTrait> dict)
        {
            this.traits = dict;
        }
         
        public FloatTrait this[string key]{ get{ return traits[key]; } }
    
        public float Size{ get{ return traits["Size"].Value; }
        public float Speed{ get{ return traits["Speed"].Value; }
    
        public DNA CombineWith(DNA other)
        {
            var newDict = this.traits.ToDictionary(k => k.Key
                                                   v => v.Value.CombineWith(other[v.Key]));
            return new DNA(newDict);
        }
    }   
