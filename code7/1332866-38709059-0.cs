	using System;
	using AutoMapper;
	namespace AutoMapOneToMulti
	{
		class Program
		{
			static void Main(string[] args)
			{
				RegiserMapps();
				var s = new Source { X = 1, Y = 2 };
				Console.WriteLine(s);
				Console.WriteLine(Mapper.Map<Source, Destination1>(s));
				Console.WriteLine(Mapper.Map<Source, Destination2>(s));
				Console.ReadLine();
			}
			static void RegiserMapps()
			{
				Mapper.Initialize(cfg => cfg.AddProfile<GeneralProfile>());
			}
		}
		public class GeneralProfile : Profile
		{
			public GeneralProfile()
			{
				CreateMap<Source, Destination1>();
				CreateMap<Source, Destination2>();
			}
		}
		public class Source
		{
			public int X { get; set; }
			public int Y { get; set; }
			public override string ToString()
			{
				return string.Format("Source = X : {0}, Y : {1}", X, Y);
			}
		}
		public class Destination1
		{
			public int X { get; set; }
			public int Y { get; set; }
			public override string ToString()
			{
				return string.Format("Destination1 = X : {0}, Y : {1}", X, Y);
			}
		}
		public class Destination2
		{
			public int X { get; set; }
			public int Y { get; set; }
			public override string ToString()
			{
				return string.Format("Destination2 = X : {0}, Y : {1}", X, Y);
			}
		}
	}
