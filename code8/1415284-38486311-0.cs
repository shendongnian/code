    public abstract class BaseClass<TType> where TType : GenericModel {
        public virtual string DoStuff(IEnumerable<TType> input) { ... }
    }
    
    public class SubClass : BaseClass<ChildModel> {
        public override string DoStuff(IEnumerable<ChildModel> input) { ... }
    }
