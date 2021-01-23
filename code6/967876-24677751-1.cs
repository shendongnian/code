    public abstract class BaseEntity { }
    public class Class1 : BaseEntity { }
    public class Class2 : BaseEntity { }
    public class SpecialClass :BaseEntity { }
    public interface ICommandHandler<T> { }
    public class InsertCommandHandler<T> : ICommandHandler<T> { }
    public class SpecialClassInsertCommandHandler : ICommandHandler<SpecialClass> { }
