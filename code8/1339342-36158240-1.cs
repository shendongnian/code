    using System;
    using NUnit.Framework;
    
    [SetUpFixture]
    public class TestInitializerInNoNamespace 
    {
    	[OneTimeSetUp]
    	public void Setup() { /* ... */ }
    
    	[OneTimeTearDown]
    	public void Teardown() { /* ... */ }
    }
