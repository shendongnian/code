    public abstract class BaseEntity { }
    public interface ICommandHandler<T> { }
    public class ClassA : BaseEntity { }
    public class ClassB : BaseEntity { }
    public class ClassC : BaseEntity { }
    public class ClassD : BaseEntity { }
    public class InsertCommandHandler<T> : ICommandHandler<T> { }
    public class SpecialInsertDCommandHandler : ICommandHandler<ClassD> { }
