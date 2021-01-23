    public interface IFaceThatAccessesIt
    {
        IList<Func<bool>> GetList();
    }
    public class ClassThatAccessesIt<T> : IFaceThatAccessesIt where T : SomeOtherType
    {
        private readonly List<Func<bool>> _innerList = new List<Func<bool>>();
        public IList<Func<bool>> GetList()
        {
            return _innerList;
        }
        public void AddToList(MyType<T> thing, Func<MyType<T>, bool> func)
        {
            _innerList.Add(() => func(thing));
        }
    }
