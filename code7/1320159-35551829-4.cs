        using System.Linq;
        using System.Collections.Generic;
		public interface IWorker {
			int[] GetParameters();
		}
		abstract class Worker : IWorker {
			public abstract int[] GetParameters();
			protected IEnumerable<int> GenerateNValues(int quanity, int min, int max) {
				var theRandom = new Random();
				var theResult = new List<int>(quanity);
				for (int i = 0; i < quanity; i++)
					theResult.Add(theRandom.Next(min, max));
				return theResult;
			}
			protected IEnumerable<int> Shuffle(IEnumerable<int> array) {
				var theRandom = new Random();
				return array.OrderBy(x => theRandom.Next()).ToArray();  
			}
		}
		class Technician : Worker {
			public override int[] GetParameters() {
				return GenerateNValues(2, 0, 100).Concat(GenerateNValues(5, 10, 51)).ToArray();
			}
		}
		class Director : Worker {
			public override int[] GetParameters() {
				return GenerateNValues(2, 50, 100).Concat(GenerateNValues(5, 10, 51)).ToArray();
			}
		}
		class Manager : Worker {
			public override int[] GetParameters() {
				return Shuffle(GenerateNValues(3, 75, 100).Concat(GenerateNValues(5, 10, 51))).ToArray();
			}
		}
		public class MyClass
		{
			public MyClass(IWorker aWorker)
			{
				var theParameters = aWorker.GetParameters();
				// do stuff with parameters
			}
		}
