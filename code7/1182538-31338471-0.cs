	public abstract class PuppyBase<TBark, TDesiredFood> : IPuppy<TBark, TDesiredFood>
		where TBark : ISound
	{
		public void Bark(TBark sound)
		{
			Console.WriteLine(sound.ToString());
		}
		public abstract Task<TDesiredFood> Sleep();
		public abstract Task Eat(TDesiredFood food);
	}
	
	public interface ISound
	{
		string ToString();
	}
