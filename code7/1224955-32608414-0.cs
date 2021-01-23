	using System;
	using NpgsqlTypes;
	using Newtonsoft.Json;
	namespace NpgsqlTest
	{
		class Program
		{
			static void Main(string[] args)
			{
				var source = new TestDto
				{
					Coord = new NpgsqlPolygon(
						new NpgsqlPoint(2.0, 3.0),
						new NpgsqlPoint(4.0, 5.0)
					)
				};
				string json = JsonConvert.SerializeObject(source);
				var result = JsonConvert.DeserializeObject<TestDto>(json);
				double x = result.Coord[0].X;
			}
		}
		public class TestDto
		{
			public NpgsqlPolygon Coord { get; set; }
		}
	}
