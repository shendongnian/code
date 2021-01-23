	using System;
	namespace Singleton
	{
		public class Session
		{
			private static object _InstanceLock = new object();
			private static Session _Instance;
			public static Session Instance
			{
				get { 
					if (_Instance == null)
					{
						lock(_InstanceLock)
						{
							if (_Instance == null)
								_Instance = new Session();
						}
					}
					return _Instance; }
			}
			// Private constructor, so that no other class can instantiate Session class
			private Session()
			{
			}
			public String UserName { get; set; }
		}
	}
