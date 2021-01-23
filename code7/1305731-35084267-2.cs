    public interface IAnimal { }
	public class Animal : IAnimal { }
	public class Turtle : Animal { }
	public class AnimalEnumerable : IEnumerable<Animal>
	{
		IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator()
		{
			throw new NotImplementedException();
		}
				
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
	public class TurtleEnumerable : AnimalEnumerable
	{
	}
