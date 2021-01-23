    public interface IAnimal { }
    public interface IGiraffe : IAnimal { }
    public interface IQuestionableCollection
    {
        IEnumerable<IAnimal> Animals { get; }
        void SomeAction();
    }
    public interface IQuestionableCollection<out T> : IQuestionableCollection
        where T : IAnimal
    {
        new IEnumerable<T> Animals { get; }
    }
    public class QuestionableCollection<T> : IQuestionableCollection<T>
        where T : IAnimal, new()
    {
        private readonly List<T> list = new List<T>();
        public IEnumerable<T> Animals
        {
            get { return list; }
        }
        IEnumerable<IAnimal> IQuestionableCollection.Animals
        {
            get { return (IEnumerable<IAnimal>)list; }
        }
        public void SomeAction()
        {
            list.Add(new T());
        }
    }
    class Giraffe : IGiraffe { }
    [TestMethod]
    public void test()
    {
        var c = new QuestionableCollection<Giraffe>();
        IQuestionableCollection<Giraffe> i = c;
        IQuestionableCollection<IGiraffe> i2 = i;
        Assert.AreEqual(0, c.Animals.Count());
        Assert.AreEqual(0, i.Animals.Count());
        c.SomeAction();
        i.SomeAction();
        Assert.AreEqual(2, c.Animals.Count());
        Assert.AreEqual(2, i.Animals.Count());
    }
