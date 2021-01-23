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
    
        [TestFixtureSetup]
        public void Test1()
        {  Console.writeLine("Test Fixture Setup"); }
    
        [TestFixtureTearDown]
        public void Test2()
        {  Console.writeLine("Test Fixture TearDown"); }
        [Test]
        public void Test1()
        {  Console.writeLine("Actual Test1"); }
    
        [Test]
        public void Test2()
        {  Console.writeLine("Actual Test2"); }
    
      }
    }
