    public static void SelectionSort<TSource, TKey>(
        List<TSource> list, 
        Func<TSource, TKey> keySelector) 
    {
        // With this method the list is sorted in ascending order. 
        //posMin is short for position of min
        int posMin;
        for (int i = 0; i < list.Count - 1; i++) {
            posMin = i;//Set posMin to the current index of array
            for (int j = i + 1; j < list.Count; j++) {
                if (keySelector(list[j]) < keySelector(list[posMin])) {
                    //posMin will keep track of the index that min is in, this is needed when a swap happens
                    posMin = j;
                }
            }
            //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
            TSource temp;
            if (posMin != i) {
                temp = list[i];
                list[i] = list[posMin];
                list[posMin] = temp;
            }
        }
    }
