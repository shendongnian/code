		public abstract class BaseClass
		{
			public string Key;
		}
		public class ConcreteClass : BaseClass
		{
		}
		public void TestFoo()
		{
			ConcreteClass sourceObject = new ConcreteClass (){ Key = "xyz" };
			
			JsonSerializerSettings _serializationSettings = new JsonSerializerSettings ()
			{ 
				NullValueHandling = NullValueHandling.Ignore, 
				TypeNameHandling = TypeNameHandling.All, 
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor, ReferenceLoopHandling = ReferenceLoopHandling.Ignore 
			};
			string json = JsonConvert.SerializeObject(sourceObject, _serializationSettings);
			Console.Out.WriteLine ("Json is {0}", json);
			BaseClass resultObject = JsonConvert.DeserializeObject<BaseClass> (json, _serializationSettings);
			Console.Out.WriteLine ("Result is {0}", resultObject);
		}
