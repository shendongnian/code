    [TestClass]
    public class ShoppingCartControllerTests {
        [TestMethod]
        public void TestCourseSchedule() {
            //Arrange
            var sr = new ScheduleRequest();
            sr.Months = null;
            sr.States = null;
            sr.Zip = null;
            sr.Miles = null;
            sr.PCodes = null;
            sr.PageStart = 1;
            sr.PageLimit = 10;
           var controller = new ShoppingCartController();
            //Set a fake request. If your controller creates responses you will need this
            controller.Request = new HttpRequestMessage {
                RequestUri = new Uri("http://localhost/api/shoppingcart"),
            };
            //Act
            // Call the controller method and test if the return data is correct.
            var response = controller.CourseSchedule(sr) as OkNegotiatedContentResult<List<EventSyn‌​cResponse>> ;;
            //Assert
            //...
        }
    }
