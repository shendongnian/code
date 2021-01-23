    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [SetUpFixture]
      public class MySetUpClass
      {
        [OneTimeSetUp]
    	RunBeforeAnyTests()
    	{
    	  Console.writeLine("SetupFixture - OneTimeSetup");
    	}
    
        [OneTimeTearDown]
    	RunAfterAnyTests()
    	{
    	  Console.writeLine("Suite TearDown - OneTimeTearDown");
    	}
      }
    }
