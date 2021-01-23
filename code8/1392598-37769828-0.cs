    namespace StudentProject.Tests.Controllers
    {
        public class StudentRosterControllerTest
        {
            [Fact]
            public void ExportToExcel_IsNotNull()
            {
                // Arrange
                StudentRostersController controller = new StudentRostersController();
                controller.ControllerContext = new ControllerContext() {
                    Controller = controller,
                    //...other properties needed for test
                };
    
                // Act
                var actionResult = controller.ExportToExcel();
    
                // Assert
                Assert.NotNull(actionResult);
            }
        }
    }
