    public interface IQuestionableCollectionBase
    {
        void SomeAction();
    }
    
    public interface IQuestionableCollection : IQuestionableCollectionBase, IEnumerable<IAnimal>
    {
    
    }
    
    public interface IQuestionableCollection<out T> : IQuestionableCollectionBase, IEnumerable<T>
        where T : IAnimal
    {
    
    }
