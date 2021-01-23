    class Customer {
          private string name;
          private string family;
          private string nameFamily;
          public string name {
               get {
                   return this.name;
               }
               private set {
                   if (!string.Equals(name, value)) {
                        this.name = value;
                        this.UpdateNameFamily();
                   }
              }
          }
          private void UpdateNameFamily() {
              this.nameFamily = string.Format("{0} {1}", this.name, this.family);
          }
          ..
          ..
    }
