    using NUnit.Framework;
    using System;
    
    namespace except
    {
    	[TestFixture ()]
    	public class Test
    	{
    		[Test ()]
    		[ExpectedException]
    		public void ExpectedException ()
    		{
    			throw new Exception ("Stackoverflow");
    		}
    
    		[Test ()]
    		[ExpectedException("System.DivideByZeroException")]
    		public void ExpectedNotSystemException ()
    		{
    			throw new Exception ("Stackoverflow");
    		}
    
    		[Test ()]
    		[ExpectedException(typeof(DivideByZeroException))]
    		public void ExpectedNotTypeOfSystemException ()
    		{
    			throw new Exception ("Stackoverflow");
    		}
    
    		[Test ()]
    		public void NotExpectedException ()
    		{
    			throw new Exception ("Stackoverflow");
    		}
    	}
    }
