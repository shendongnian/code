	using System;
	public class Test
	{
		public static void Main()
		{
			var c1 = ChallengeManager.CreateChallenge();
			var c2 = ChallengeManager.CreateChallenge();
			//var c = ChallengeManager.CreateChallenge<Challenage>(); // This statement won't compile
		}
	}
	public class ChallengeManager
	{
		public static Challenage CreateChallenge()
		{
			// identify which challenge to instantiate. e.g. Challenage1
			var c = CreateChallenge<Challenage1>();
			return c;
		}
		
		private static Challenage CreateChallenge<T>() where T: Challenage, new()
		{
			return new T();
		}
	}
	public abstract class Challenage{}
	public class Challenage1: Challenage{}
	public class Challenage2: Challenage{}
