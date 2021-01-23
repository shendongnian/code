    [TestClass]
    public class WebUnitTests
    {
       [TestMethod]
       public void Can_Request_Employee_Id()
       {
           // Arrange
           YourHttpRequestClass c = new YourHttpRequestClass();
           var employeeId = c.GetEmployeeId();
    
           // Assert
           Assert.IsFalse(string.IsNullOrEmpty(employeeId));
           
       }
    }
