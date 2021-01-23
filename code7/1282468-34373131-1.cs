    class Symbol : IEquatable<Symbol>
    {
        private object o = new object();
        public string Description { get; }
        public Symbol(string description)
        {
            Description = description;
        }
        public Symbol() : this(null) { }
    
        public bool Equals(Symbol other) => other?.o == o;
        public static bool operator == (Symbol o1, Symbol o2) => 
            EqualityComparer<Symbol>.Default.Equals(o1, o2);
        public static bool operator !=(Symbol o1, Symbol o2) => !(o1 == o2);
        public override int GetHashCode()
        {
            return o.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Symbol);
        }
        public override string ToString() => $"symbol({Description})";
    
        // static methods to support symbol registry
        private static Dictionary<string, Symbol> GlobalSymbols = 
              new Dictionary<string, Symbol>(StringComparer.Ordinal);
        public static Symbol For(string key) => 
              GlobalSymbols.ContainsKey(key) ? 
                    GlobalSymbols[key] :
                    GlobalSymbols[key] = new Symbol(key);
        public static string KeyFor(Symbol s) =>
              GlobalSymbols.FirstOrDefault(a => a.Value == s).Key; // returns null if s not defined
    
        // Well-known ECMAScript symbols
        private const string ns = "Symbol.";
        public static Symbol HasInstance => For(ns + "hasInstance");
        public static Symbol IsConcatSpreadable => For(ns + "isConcatSpreadable");
        public static Symbol Iterator => For(ns + "iterator");
        public static Symbol Match => For(ns + "match");
        public static Symbol Replace => For(ns + "replace");
        public static Symbol Search => For(ns + "search");
        public static Symbol Species => For(ns + "species");
        public static Symbol Split => For(ns + "split");
        public static Symbol ToPrimitive => For(ns + "toPrimitive");
        public static Symbol ToStringTag => For(ns + "toStringTag");
        public static Symbol Unscopables => For(ns + "unscopables");
    }
