    .namespace A
    {
    	.namespace B
    	{
    		.class public auto ansi beforefieldinit C
    			extends [mscorlib]System.Object
    		{
    			// Nested Types
    			.class nested public auto ansi beforefieldinit D
    				extends [mscorlib]System.Object
    			{
    				// Methods
    				.method public hidebysig specialname rtspecialname 
    					instance void .ctor () cil managed 
    				{
    					// Method begins at RVA 0x2050
    					// Code size 7 (0x7)
    					.maxstack 8
    
    					IL_0000: ldarg.0
    					IL_0001: call instance void [mscorlib]System.Object::.ctor()
    					IL_0006: ret
    				} // end of method D::.ctor
    
    			} // end of class D
    
    
    			// Methods
    			.method public hidebysig specialname rtspecialname 
    				instance void .ctor () cil managed 
    			{
    				// Method begins at RVA 0x2050
    				// Code size 7 (0x7)
    				.maxstack 8
    
    				IL_0000: ldarg.0
    				IL_0001: call instance void [mscorlib]System.Object::.ctor()
    				IL_0006: ret
    			} // end of method C::.ctor
    
    		} // end of class A.B.C
    	}
    }
