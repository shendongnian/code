	public class myTest
	{
		public class Person
		{
			protected Dictionary<string, object> _properties;
			
			public Person()
			{
				_properties = new Dictionary<string, object>();
			}
		
			public Int32 Id 
			{ 
				get 
				{ 
					return (int)_properties[EPerson.Id];
				} 
				set
				{
					_properties[EPerson.Id] = value;
				}
			}
			public String Fname 
			{ 
				get 
				{ 
					return _properties[EPerson.FName] as String;
				} 
				set
				{
					_properties[EPerson.FName] = value;
				}
			}
			public string Lname
			{ 
				get 
				{ 
					return _properties[EPerson.LName] as String;
				} 
				set
				{
					_properties[EPerson.LName] = value;
				}
			}
		}
		
		public enum EPerson
		{
			Id = 0,
			Fname = 1,
			Lname = 2
		}
		
		public static void Get(EPerson SearchBy, dynamic Value)
		{
			var Sql = "select from dbo.bobo where " + SearchBy.ToString() + "='" + Value + "'";
		}
		public static void testget()
		{
			Get(EPerson.Fname, "Bob");
		}
	}
