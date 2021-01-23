    public System.Collections.IList SelectedItems {
        get {
          return ObjectCollection;
        }
        set {
          ObjectCollection.Clear();
          foreach (var model in value) {
            ObjectCollection.Add(model);
          }
        }
      }
