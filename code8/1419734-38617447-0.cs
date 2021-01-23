    protected static IEnumerable<Control> GetAllChildren(Control root) {
      return new Control[] { root }
        .Concat(root.Controls
          .OfType<Control>()
          .SelectMany(item => GetAllChildren(item)));
    }
