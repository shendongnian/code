    using System;
    using System.Drawing;
    using MonoMac.Foundation;
    
    namespace OPN200x
    {
    	// @interface SimpleClass : NSObject
    	[BaseType (typeof(NSObject))]
    	interface SimpleClass
    	{
    		// -(NSString *)run;
    		[Export ("run")]
    		string Run { get; }
    	}
    }
