    namespace N1
    {
    	namespace N12 { }
    }
    
    namespace N2
    {
    	using R1 = N1;
    
    	namespace N2
    	{
    		using R2 = R1.N12;
    	}
    }
