    public static class Extensions{
        public static int GetScale(this decimal value){
    	if(value == 0)
                return 0;
    	int[] bits = decimal.GetBits(value);
    	return (int) ((bits[3] >> 16) & 0x7F); 
        }
    
        public static int GetPrecision(this decimal value){
    	if(value == 0)
    	    return 0;
    	int[] bits = decimal.GetBits(value);
        //We will use false for the sign (false =  positive), because we don't care about it.
        //We will use 0 for the last argument instead of bits[3] to eliminate the fraction point.
    	decimal d = new Decimal(bits[0], bits[1], bits[2], false, 0);
    	return (int)Math.Floor(Math.Log10((double)d)) + 1;
        }
    }
