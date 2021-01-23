    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [TestFixture]
      public class SuccessTests
      {
        [SetUp] 
        public void Init()
        {  Console.writeLine("Test Setup"); }
    
        [TearDown]
        public void Cleanup()
        {  Console.writeLine("Test Teardown"); }
    
        [OneTimeSetup]
        public void Test1()
        {  Console.writeLine("Test Fixture - OneTimeSetup"); }
    
        [OneTimeTearDown]
        public void Test2()
        {  Console.writeLine("Test Fixture - OneTimeTearDown"); }
        [Test]
        public void Test1()
        {  Console.writeLine("Actual Test1"); }
    
        [Test]
        public void Test2()
        {  Console.writeLine("Actual Test2"); }
    
      }
    }
