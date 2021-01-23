    class Pair
    {
        public char Key { get; set; }
        public int? Value { get; set; }
    }
    
    var pairs = new[] { new Pair { Key = 'a', Value = 15 },
                        new Pair { Key = 'b', Value = null },
                        new Pair { Key = 'a', Value = null }
    }
    
    var nullOnlyPairs = pairs.Where(p => !pairs.Any(a => a.Key == p.Key && a.Value != null));
