    public interface IQuestionableCollection : IEnumerable<IAnimal>
    {
        void SomeAction();
    }
    
    public interface IQuestionableCollection<out T> : IQuestionableCollection, IEnumerable<T>
        where T : IAnimal
    {
    
    }
