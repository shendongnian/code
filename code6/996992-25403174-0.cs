    public interface IIdProvider {
        int? Id { get; }
    }
    public class Class1 : IIdProvider {
        int? IIdProvider.Id { 
            get {
                return SomeProperty != null ? SomeProperty.Id : null;
            }
        }
    }
    public class Class2 : IIdProvider {
       int? IIdProvider.Id { 
            get {
                return AnotherProperty != null ? AnotherProperty.AnotherId : null;
            }
        }
    }
