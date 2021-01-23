    using myExtension;
    namespace yourNameSpace
    {
    	public partial class YourClass
        {
    		public void YourMethod
    		{
    			double d1 = 232.00000000.myRoundOff();  // ANS -> 232
                double d2 = 0.18000000000.myRoundOff(); // ANS -> 0.18
                double d3 = 1237875192.0.myRoundOff();  // ANS -> 1237875192
                double d4 = 4.5800000000.myRoundOff();  // ANS -> 4.58
                double d5 = 0.00000000.myRoundOff();    // ANS -> 0
                double d6 = 1.23450000.myRoundOff();    // ANS -> 1.2345
    		}
    	}
    }
