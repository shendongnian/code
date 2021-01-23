    // since you've declared Equals(Foo other) let others know via interface implementation
    public class Foo: IEquatable<Foo> { 
      public string MyOwnId { get; set; }
      public Guid FooGuid { get; } = Guid.NewGuid();
      public bool Equals(Foo other) {
        if (Object.ReferenceEquals(this, other))
          return true;
        else if (Object.ReferenceEquals(null, other))
          return false;
        else
          return String.Equals(MyOwnId, other.MyOwnId);
      }
      public override bool Equals(object obj) {
        return Equals(obj as Foo); // do not repeat youself: you've got Equals already
      }
      public override int GetHashCode() {
        // String.GetHashCode is good enough, do not re-invent a wheel
        return null == MyOwnId ? 0 : MyOwnId.GetHashCode(); 
      }
    }
