    public static class PreCondition {
  
        [Pure]
        public static Boolean CollectionContainsNull(IEnumerable<T> collection){
            Contract.Requires<ArgumentNullException(collection != null);
            
            if (typeof(T).IsValueType)
                return false;
            return collection.Any(x => Object.Equals(x, null));
        }
        [ContractAbbreviator]
        public static void NotIsOrHasNull<T>(IEnumerable<T> collection){
            Contract.Requires<ArgumentNullException(collection != null,   
                "Collection cannot be null.");
            Contract.Requires<ArgumentNullException>(!CollectionContainsNull(collection)), 
                "Collection cannot contain null.");
        }
    }
