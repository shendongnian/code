				class A
				{
					public virtual void print()
					{
						Console.WriteLine("A called");
						Console.Read();
					}
				}
				class B :A
				{
					public override void print()
					{
						Console.WriteLine("B called");
						Console.Read();
					}
				}
				class C : B
				{
					public void somerandommethod()
					{
						// some random method not really relevant to this example.
					}
				}
				static void Main(string[] args)
				{
					A a = new C();
					a.print(); // it will now print B (since B has the most derived implementation of print())
					
				}
				
				
