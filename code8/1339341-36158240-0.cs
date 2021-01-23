    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class TestInitializerInNoNamespace 
    {
    	[OneTimeSetUp]
    	public void Setup() { /* ... */ }
    
    	[OneTimeTearDown]
    	public void Teardown() { /* ... */ }
    }
