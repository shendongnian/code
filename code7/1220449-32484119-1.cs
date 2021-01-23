    public class FOO {
      private object idLock = new Object();
      // immutable Id class
      public class Id {
       public Id(....){...}
       public Guid UniqueIdentifier {get; private set;}
       public string UserName {get; private set;}
      }
      private Id id;
      public Id { get {lock(idLock){ return id;}}
                  set {lock(idLock){ id = value;}}
    }
