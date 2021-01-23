        public interface IAnimal
        {
    
        }
    
        public interface IGiraffe : IAnimal
        {
    
        }
    
        public interface IQuestionableCollectionBase
        {
            void SomeAction();
        }
    
        //I declared this Abstract because I feel you may want to have one definition of SomeAction for all concrete implementaion
        //or one concrete implementation of GetEnumerator. Don't have enough information to make a good decision here.
        public abstract class AbsQuestionableCollection<T> : IQuestionableCollectionBase, IEnumerable<T> where T : IAnimal
        {
            public abstract void SomeAction();
            public abstract IEnumerator<T> GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    
        public class QuestionableCollection<T> : AbsQuestionableCollection<T> where T : IAnimal
        {
            public override void SomeAction()
            {
                throw new NotImplementedException();
            }
    
            override public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
