    public interface IQuestionableCollectionBase
    {
        void SomeAction();
    }
    
    public interface IQuestionableCollection<T> : IQuestionableCollectionBase, IEnumerable<T> where T : IAnimal
    {
    
    }
