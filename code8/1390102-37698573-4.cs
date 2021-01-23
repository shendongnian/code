    // Note that you have to build a custom type for your list items to keep high performance,
    // or write this code inline instead of as a function
    bool IsMySpecificListTypeSorted(List<MyCustomListItemType> theList) {
        int previousOrdinal = -1;
        // Not using foreach because it is "8x slower" in tests
        // and you're micro-optimizing in this scenario
        for(int index = 0; index < theList.Count; ++index) {
            var item = theList[index];
            var currentOrdinal = (int)item.Action;
            if(currentOrdinal < previousOrdinal) {
                return false;
            }
            previousOrdinal = currentOrdinal;
        }
        return true;
    }
