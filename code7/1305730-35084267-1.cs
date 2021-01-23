    public interface IAnimal { }
	public class Animal : IAnimal { }
	public class Turtle : Animal { }
	public class AnimalEnumerable : IEnumerable<Animal>
	{
		protected IEnumerator<Animal> GetEnumerator()
		{
				return GetEnumerator();
		}
		 IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator()
		{
			throw new NotImplementedException();
		}
				
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
	public class TurtleEnumerable : AnimalEnumerable, IEnumerable<Turtle>
	{
		IEnumerator<Turtle> IEnumerable<Turtle>.GetEnumerator()
		{
			return (IEnumerator<Turtle>)(base.GetEnumerator());	
		}
	}
