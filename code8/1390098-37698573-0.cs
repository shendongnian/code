    bool IsMySpecificListTypeSorted(theList) {
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
