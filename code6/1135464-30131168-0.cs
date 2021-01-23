    public interface IAnimal
    {
    
    }
    
    public interface IGiraffe : IAnimal
    {
    
    }
    
    public interface IQuestionableCollection<T> : IEnumerable<T> where T : IAnimal
    {
        void SomeAction();
    }
    
    public interface IQuestionableCollection : IQuestionableCollection<IAnimal>
    {
        
    }
    
    public class QuestionableCollection<T> : IQuestionableCollection<T>, IEnumerable<T>
        where T : IAnimal
    {
        public void SomeAction() { }
    
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
