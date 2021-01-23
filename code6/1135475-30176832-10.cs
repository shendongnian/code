     public class QuestionableCollection : IQuestionableCollection, IEnumerable<IAnimal> 
    {
        public IEnumerator<IAnimal> GetEnumerator()
        {
            var l = new List<Giraffe>();
            l.Add(new Giraffe());
            l.Add(new Giraffe());
            return l.GetEnumerator();
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
