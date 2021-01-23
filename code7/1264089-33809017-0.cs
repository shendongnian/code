	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication6
	{
		public class Base
		{
			public virtual void DoStuff(){}
		}
		public class Derived1 : Base
		{
			public virtual void DoStuff(){}
        }
		public class Derived2 : Base
		{
			public virtual void DoStuff(){}
		}
		public class WorkerClass<T> : Base where T : Base,new()
		{
			public WorkerClass() { }
			public override void DoStuff()
			{
				T container = new T();
				// do stuff
			}
		}
