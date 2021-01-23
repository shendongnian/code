    // If you want to pass many items, pass IEnumerable<T> 
    bool TestRange(IEnumerable<int> numbersToCheck, int bottom, int top) {
      if (null == numberToCheck)
        throw new ArgumentNullException("numbersToCheck"); // or return true or false... 
    
      return numbersToCheck.All(item => item >= bottom && top <= item);
    }
    
    ...
    
    if (TestRange(new int[] {20121, 20131}, 20101, 20141)) {...}
