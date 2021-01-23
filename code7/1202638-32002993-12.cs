    class CountsDictionary<T> : DynamicObject where T : struct, IConvertible {
    
      readonly IDictionary<Int32, Int32> dictionary;
    
      public CountsDictionary(IEnumerable<Tuple<T, Int32>> counts) {
        if (counts == null)
          throw new ArgumentNullException("counts");
        this.dictionary = counts.ToDictionary(
          t => Convert.ToInt32(t.Item1),
          t => t.Item2
        );
      }
    
      public override Boolean TryGetMember(GetMemberBinder binder, out Object result) {
        Int32 value;
        if (binder.Name.StartsWith("CountType") && Int32.TryParse(binder.Name.Substring(9), NumberStyles.None, CultureInfo.InvariantCulture, out value) && value >= 0) {
          result = this.dictionary.ContainsKey(value) ? this.dictionary[value] : 0;
          return true;
        }
        result = 0;
        return false;
      }
    
    }
