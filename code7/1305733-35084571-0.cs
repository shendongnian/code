        public interface IAnimal { }
        public class Animal : IAnimal { }
        public class Turtle : Animal { }
        public class AnimalEnumerable : IEnumerable<Animal>
        {
            protected List<Animal> Animals = new List<Animal>();
            public IEnumerator<Animal> GetEnumerator()
            {
                return Animals.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return Animals.GetEnumerator();
            }
        }
        public class TurtleEnumerable : AnimalEnumerable
        {
            public void AddTurtle(Turtle turtle)
            {
                Animals.Add(turtle);
            }
            public IEnumerable<Turtle> GetTurtles()
            {
                var iterator = GetEnumerator();
                yield return iterator.Current as Turtle;
            }
        }
        [Test]
        public void CanAddTurtles()
        {
            Turtle one = new Turtle();
            Turtle two = new Turtle();
            TurtleEnumerable turtleStore = new TurtleEnumerable();
            turtleStore.AddTurtle(one);
            turtleStore.AddTurtle(two);
            
            foreach (var turtle in turtleStore.GetTurtles())
            {
                // Do something with the turtles....
            }
        }
