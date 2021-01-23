    class Factory(IContainer c) {
      public ICar GetCar(string name) {
        Return c.GetNamedInstance(name);
      }
    }
