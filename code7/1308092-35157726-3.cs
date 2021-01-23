    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [SetUpFixture]
      public class MySetUpClass
      {
        [SetUp]
    	RunBeforeAnyTests()
    	{
    	  Console.writeLine("Suite Setup");
    	}
    
        [TearDown]
    	RunAfterAnyTests()
    	{
    	  Console.writeLine("Suite TearDown");
    	}
      }
    }
