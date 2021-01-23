    [TestClass]
    public class MvcControllerAttributeRouteTests : ControllerUnitTests {
        [TestMethod]
        public void Index_Should_Return_ViewResult_With_Model() {
            //Arrange
            int project = 5;
            int step = 6;
            var controller = new ATController();
            //Act
            var actionResult = controller.Index(project, step);
            var viewResult = actionResult as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(ATViewModel));
            var viewModel = viewResult.Model as ATViewModel;
            Assert.AreEqual(project, viewModel.Project);
            Assert.AreEqual(step, viewModel.Step);
        }
        [TestMethod]
        public void Project_Supplied_No_Step_Should_Redirect_To_Index() {
            //Arrange
            int project = 1;
            var controller = new ATController();
            //Act
            var actionResult = controller.ProjectSuppliedNoStep(project);
            var result = actionResult as RedirectToRouteResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"], "the redirection was to at.index action");
            Assert.AreEqual(project, result.RouteValues["project"]);
        }
        [TestMethod]
        public void No_Porject_No_Step_Should_Redirect_To_Index() {
            //Arrange
            var controller = new ATController();
            //Act
            var actionResult = controller.NoProjectNoStep();
            var result = actionResult as RedirectToRouteResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"], "the redirection was to at.index action");
            CollectionAssert.Contains(result.RouteValues.Keys, "project");
            CollectionAssert.Contains(result.RouteValues.Keys, "step");
        }
    }
