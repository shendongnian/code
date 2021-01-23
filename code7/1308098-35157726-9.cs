    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [SetUpFixture]
      public class MySetUpClass
      {
        [OneTimeSetUp]
    	public void RunBeforeAnyTests()
    	{
    	  Console.WriteLine("SetupFixture - OneTimeSetup");
    	}
    
        [OneTimeTearDown]
    	public void RunAfterAllTests()
    	{
    	  Console.WriteLine("Suite TearDown - OneTimeTearDown");
    	}
      }
    }
