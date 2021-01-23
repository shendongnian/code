    [TestClass]
    public class MyTests
    {
       [TestMethod]
       private void AddData_SwitchValueOf15_ShouldAddToStorageTwo()
       {
          // Mock the repository then add it to the service
          Mock<IRepository> mockRepository = new Mock<IRepository>();
          MyService service = new MyService
          {
             Repository = mockRepository 
          };
    
          MyDataObject myDataObject = new MyDataObject();
          // Assign some data to myDataObject
    
          // This should insert myDataObject into StorageTwo
          service.AddData(myDataObject, 15);
    
          // Check that the correct method was called once, with our parameter
          mockRepository.Verify(r => r.AddToStorageTwo(myDataObject), Times.Once());
          // Check that the other methods were never called, with any input
          mockRepository.Verify(r => r.AddToStorageOne(It.IsAny<MyDataObject>()), Times.Never());
          mockRepository.Verify(r => r.AddToStorageThree(It.IsAny<MyDataObject>()), Times.Never());
       }
    }
