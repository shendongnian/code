	class Program
	{
		static void Main(string[] args)
		{
			char[] oddF           = new char[8]{'0','1','8','A','b','9','a','B'};
			 int[] oddFValue      = new int[8];
			
			Dictionary<char, int> table = new Dictionary<char, int>(){
				{ '0', 1  },
				{ '1', 0  },
				{ '8', 19 },
				{ '9', 21 },
				{ 'a', 1  },
				{ 'A', 1  },
				{ 'b', 0  },
				{ 'B', 0  }
			};
			for (int i = 0; i < 8; i++)
			{
				oddFValue[i] = table[oddF[i]]; // Lookup which function should be called, and call it.
			}
        }
    }
