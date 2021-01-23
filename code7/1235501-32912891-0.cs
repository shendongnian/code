    void Main()
    {
    	Console.WriteLine(Dog.Fido.ToString());
    }
    
    public abstract class Enumeration<T> where T : Enumeration<T>
    {
    	private static IEnumerable<T> enumerateAllValues()
    	{
    		// Obviously use some caching here
    		var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
    		return fields.Select(f => f.GetValue(null)).OfType<T>();
    	}
    
    	internal static IEnumerable<T> AllValues { get { return enumerateAllValues();}}
    
    	protected Enumeration(int value, string displayName)
    	{
    		if (!typeof(T).IsSealed)
    			throw new NotSupportedException($"Value objects must be sealed, {typeof(T).Name} is not.");
    		this.Value = value;
    		this.DisplayName = displayName;
    	}
    	
    	protected int Value { get; }
    	
    	protected string DisplayName { get; }
    	
    	public override string ToString() { return DisplayName; }       
    	    // IEquatable implementation based solely on this.Value
    }
    
    public static class Enumeration
    {
    	public static IEnumerable<T> GetAllValues<T>() where T : Enumeration<T>
    	{
    		return Enumeration<T>.AllValues;
    	}
    	// Other helper methods, e.g. T Parse(int), bool TryParse(int, out T), etc.
    }
    
    public abstract class AnimalTrait<T> : Enumeration<T>
    	where T : AnimalTrait<T>
    {
    	protected AnimalTrait(int value, string displayName) : base(value, displayName) {; }
    }
    
    public struct AnimalTraitValuePair<TAnimalTrait> where TAnimalTrait : AnimalTrait<TAnimalTrait>
    {
    
    	public TAnimalTrait AnimalTrait { get; }
    
    	public string Value { get; } // Analogy breaks down here, but lets assume we know that the values of animal traits are always strings.
    
    	public AnimalTraitValuePair(TAnimalTrait animalTrait, string value)
        {
            this.AnimalTrait = animalTrait;
            this.Value = value;
        }
    
    	public override string ToString()
    	{
    		return $"[{AnimalTrait}, {Value}]";
    }
    }
    
    public abstract class Animal<TAnimal, TAnimalTrait> : Enumeration<TAnimal>
    	where TAnimal : Animal<TAnimal, TAnimalTrait>
    	where TAnimalTrait : AnimalTrait<TAnimalTrait>
    {
    	private readonly IList<AnimalTraitValuePair<TAnimalTrait>> animalTraitValuePairList;
    
    	// All animals have a name
    	public string Name { get; }
    
    	protected Animal(int i, string name, IEnumerable<AnimalTraitValuePair<TAnimalTrait>> animalTraitValuePairs)
    		: base(i, name)
    	{
    		animalTraitValuePairList = animalTraitValuePairs.ToList();
    		this.Name = name;
    	}
    
    	public string this[TAnimalTrait animalTrait]
    	{
    		get
    		{
    			return animalTraitValuePairList.First(atvp => atvp.AnimalTrait == animalTrait).Value;
    		}
    	}
    
    	public override string ToString()
    	{
    		StringBuilder sb = new StringBuilder();
    		sb.AppendLine($"{this.Name}'s traits:");
    		foreach (var animalTrait in Enumeration.GetAllValues<TAnimalTrait>())
    		{
                sb.AppendLine($"[{animalTrait}, {this[animalTrait]}]");
            }
    		return sb.ToString();
    	}
    }
    
    public sealed class DogTrait : AnimalTrait<DogTrait>
    {
    	public DogTrait(int i, string name) 
    		: base(i, name)
    	{ }
    	public static DogTrait Color = new DogTrait(1, "Color");
    	public static DogTrait Size = new DogTrait(2, "Size");
    }
    
    public sealed class Dog : Animal<Dog, DogTrait>
    {
    	public Dog(int i, string name, IEnumerable<AnimalTraitValuePair<DogTrait>> animalTraitValuePairs)
    		: base(i, name, animalTraitValuePairs)
    	{
    	}
    	public static Dog Fido = new Dog(1, "Fido", new[] {
    		new AnimalTraitValuePair<DogTrait>(DogTrait.Color, "Black"),
    		new AnimalTraitValuePair<DogTrait>(DogTrait.Size, "Medium"),
    	});
    }
