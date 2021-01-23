      public static class RichTextBoxExtensions {
        public static int FindAny(this RichTextBox source, params String[] toFind) {
          if (null == source)
            throw new ArgumentNullException("source");
          else if (null == toFind)
            throw new ArgumentNullException("toFind");
    
          int result = -1;
          foreach (var item in toFind) {
            if (null == item)
              continue;
            int v = source.Find(item);
            if ((v >= 0) && ((result < 0) || (v < result)))
              return = v;
          }
          return result;
        }
      }
    
    ....
    
      int result = richtextbox.FindAny("something", "somethingelse");
