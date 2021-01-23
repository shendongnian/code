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
            var json = JsonConvert.SerializeObject(sr);
            //construct content to send
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage {
                RequestUri = new Uri("http://localhost/api/shoppingcart"),
                Content = content
            };
            var controller = new ShoppingCartController();
            //Set a fake request. If your controller creates responses you will need this
            controller.Request = request;
            //Act
            // Call the controller method and test if the return data is correct.
            var response = controller.CourseSchedule(request) as OkNegotiatedContentResult<List<EventSyn‌​cResponse>> ;
            //Assert
            //...other asserts
        }
    }
