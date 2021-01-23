	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace ConsoleApplication2
	{
		class Program
		{
			internal class Foo {
				public int Index { get; set; }
				public Foo(int index)
				{
					this.Index = index;
				}
			}
			internal class Bar {
				public string Text { get; set; }
				public Bar(string text)
				{
					this.Text = text;
				}
			}
			static void Main(string[] args)
			{
				Foo[] __a = new[] { new Foo(4), new Foo(3), new Foo(2), new Foo(1), new Foo(0) };
				Bar[] __b = new[] { new Bar("Y"), new Bar("Z"), new Bar("Z"), new Bar("Y"), new Bar("X") };
				// Sort all foos, by Value, keeping the original index.
				var sorted = __a.Select((x, i) => new KeyValuePair<Foo, int>(x, i)).OrderBy(x => x.Key.Index);
				// Retrieve the sorted foos as a Foo[].
				var sortedFoos = sorted.Select(x => x.Key).ToArray();
				// Pick the bars according to the original index of the foos.
				var sortedBars = sorted.Select(x => __b[x.Value]).ToArray();
				Console.WriteLine(string.Concat(sortedFoos.Select(x => x.Index)));
				Console.WriteLine(string.Concat(sortedBars.Select(x => x.Text)));
			}
		}
	}
----------
	01234
	XYZZY
	Press any key to continue . . .
