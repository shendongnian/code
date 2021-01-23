    private bool IsSubstring(string child, string parent) {
      for (int i = 0; i < child.Length; i+= 6) {
        if (!parent.Contains(child.Substring(i, 6))) {
          return false;
        }
      }
      return true;
    }
