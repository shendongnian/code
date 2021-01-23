        public enum AlphaNumber
    	{ 
    		A=2, B=2, C=2, D=3, E=3, F=3, G=4, H=4, I=4, J=5, K=5, L=5, 
    		M=6, N=6, O=6, P=7, Q=7, R=7, S=8, T=8, U=8, V=9, W=9, X=9, Y=9, Z=9
    	}
    	
    	public static class PhoneNumber
    	{
    		public static char ParseInput(char input)
    		{
    			if (input == '-' || char.IsDigit(input))
    			{
    				return input;
    			}
    			
    			if (char.IsLetter(input))
    			{
    				var num = (AlphaNumber)(Enum.Parse(typeof(AlphaNumber), (char.IsLower(input) ? char.ToUpperInvariant(input) : input).ToString()));
    				return ((int)num).ToString()[0];
    			}
    			
    			return '\0';
    		}
    	}
