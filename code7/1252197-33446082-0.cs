    public bool CanUpdate {
      get {
        return (this.Properties & CharacteristicPropertyType.Notify) != 0;
      }
    }
