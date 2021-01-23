    public class Metrics
		{
			private static Metrics _instance;
            public static Metrics Instance
			{
				get{
					if (_instance == null)
						_instance = new Metrics();
					return _instance;
				}
			}
            protected SessionData ()
			{
			}
            
            public double Width{ get; set; } //Width
			public double Height{ get; set; } //Height
            }
