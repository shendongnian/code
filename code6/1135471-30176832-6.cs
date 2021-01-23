        public interface IAnimal {}
    
        public interface IGiraffe : IAnimal { }
    
        public interface IQuestionableCollection : IEnumerable
        {
            void SomeAction();
        }
    
        public interface IQuestionableCollection<out T> : IQuestionableCollection, IEnumerable<T>
         where T : IAnimal
        { }
    
        public class QuestionableCollection<T> : IQuestionableCollection<T>
            where T : IAnimal
        {
    
            private List<T> list = new List<T>(); 
    
            public IEnumerator<T> GetEnumerator()
            {
                return list.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public void SomeAction()
            {
                throw new NotImplementedException();
            }
        }
    
          class Program
        {
            static void Main(string[] args)
            {
                var questionable = new QuestionableCollection<IGiraffe>();
                foreach (IGiraffe giraffe in questionable)
                {
                    
                }
            }
        }
