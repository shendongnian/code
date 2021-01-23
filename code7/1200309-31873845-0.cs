    namespace N1.N2 {}
    namespace N3
    {
    	using R2 = N1;			// OK
    	using R3 = N1.N2;		// OK
    	using R4 = R2.N2;		// Error, R2 unknown
    }
