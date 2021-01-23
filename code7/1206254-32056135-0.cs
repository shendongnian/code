    public interface IAnimalShelter<T> where T : IAnimal
	{
		List<T> Animals { get; set; }
	}
    public class Cat: IAnimal
	{
	}
    public interface ICatShelter : IAnimalShelter<Cat>
	{
	}
    public class CatShelter: ICatShelter
	{
		public List<Cat> Animals { get; set; }
	}
