    public static IList<IList<T>> GetPermutations<T>(IList<IList<T>> inputLists) {
        if (inputLists.Count < 2) {
            // special case. 
        }
        return _permutationHelper(0, inputLists);
    }
    private static IList<IList<T>> _permutationHelper<T>(int i, IList<IList<T>> inputLists) {
        IList<IList<T>> returnValue = new List<IList<T>>();
        if (i == inputLists.Count) {
            returnValue.Add(new List<T>());
        } else {
            foreach (var t in inputLists[i]) {
                foreach (var list in _permutationHelper(i + 1, inputLists)) {
                    list.Add(t);
                    returnValue.Add(list);
                }
            }
        }
        return returnValue;
    }
