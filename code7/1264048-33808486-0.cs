	class RandomNumberGenerator
	{
	
		static MersenneTwisterClass RNG = null;
		static object RNGLock = new object();
		static int counter = 0;
		
		public RandomNumberGenerator()
		{
			Init();
		}
		
		void Init()
		{
			// Multithreading lock
			lock (RNGLock)
			{
				// Seed it or don't, your call
				RNG = new MersenneTwisterClass(some_seed_value_or_nah);
                counter = 0;
			}
		}
		
		public decimal GetValue()
		{
			lock (RNGLock)
			{
				counter++;
				if (counter > 500)
				{
					Init();
				}
				return RNG.GetValue();
			}
		}
	
		public long GetRange(long min, long max)
		{
			lock (RNGLock)
			{
				counter++;
				if (counter > 500)
				{
					Init();
				}
				return RNG.GetRange(min, max);
			}
		}
	
	}
    
