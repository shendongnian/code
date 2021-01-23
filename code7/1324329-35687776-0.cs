    public static class XElementExtensions
    {
      public static XElement SafeGetChild(this XElement node, string childName)
      {
        XElement result;
        if (!node.TryGetChildByName(childName, out result))
          result = node.Document.CreateElement(childName);
        return result;
      }
    }
