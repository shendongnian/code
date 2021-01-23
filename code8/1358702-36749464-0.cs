    public static class PreCondition {
        [ContractAbbreviator]
        public static void NotIsOrHasNull<T>(IEnumerable<T> collection){
            Contract.Requires<ArgumentNullException(collection != null,   
                "Collection cannot be null.");
            Contract.Requires<ArgumentNullException>(collection.All(x => x != null), 
                "Collection cannot contain null.");
        }
    }
