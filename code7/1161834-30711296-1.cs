    [TestCase]
    public class MammalTest
    {
        [TestMethod]
        AbstractMethodNameHere_YourTestCase_YourExpectedResults()
        {
           Mammal pet = new Dog();
    
           // Here you could test the method that has been implemented 
           // in the base class.
           Assert.IsTrue(pet.AbstractMethodNameHere());
        }
    }
