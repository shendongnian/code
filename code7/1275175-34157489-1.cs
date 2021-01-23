    for (int i = A.Count; i >= 0; i--) {
      if (!B.Contains(A[i])) {
        A.RemoveAt(i);
      }
    }
    foreach (var item in B) {
      if (!A.Contains(item)) {
        A.Add(item);
      }
    }
