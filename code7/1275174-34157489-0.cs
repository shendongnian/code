    foreach (var item in A) {
      if (!B.Contains(item)) {
        A.Remove(item);
      }
    }
    foreach (var item in B) {
      if (!A.Contains(item)) {
        A.Add(item);
      }
    }
