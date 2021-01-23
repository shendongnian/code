    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [TestFixture]
      public class SuccessTests
      {
        [SetUp] 
        public void SetUp()
        {  Console.WriteLine("Test Setup"); }
    
        [TearDown]
        public void TearDown()
        {  Console.WriteLine("Test Teardown"); }
    
        [OneTimeSetup]
        public void OneTimeSetup()
        {  Console.WriteLine("Test Fixture - OneTimeSetup"); }
    
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {  Console.WriteLine("Test Fixture - OneTimeTearDown"); }
        [Test]
        public void Test1()
        {  Console.WriteLine("Actual Test1"); }
    
        [Test]
        public void Test2()
        {  Console.WriteLine("Actual Test2"); }
    
      }
    }
