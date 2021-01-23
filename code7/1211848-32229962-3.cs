      public static class ActivableExtensions {
        public static void Activate(this IActivable source) {
          if (null == source)
            throw new ArgumentNullException("source");   
          
          source.IsActive = true;
        }
      }
