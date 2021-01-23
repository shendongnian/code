    [TestClass]
    public class DynamicObjectWrapperTests {
        [TestMethod]
        public void DynamicObjectResultValue_Member_Should_Exist() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousObject() as JsonResult;
            //Assert
            dynamic obj = result.Value.AsDynamicObject();
            Assert.IsNotNull(obj);
            Assert.AreEqual(1, obj.id);
            Assert.AreEqual("Foo", obj.name);
            Assert.AreEqual(3, obj.name.Length);
            Assert.AreEqual("Bar", obj.type);
        }
        [TestMethod]
        public void DynamicObjectResultValue_DynamicCollection() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousCollection() as JsonResult;
            //Assert
            dynamic jsonCollection = result.Value;
            foreach (object value in jsonCollection) {
                dynamic json = value.AsDynamicObject();
                Assert.IsNotNull(json.id,
                    "JSON record does not contain \"id\" required property.");
                Assert.IsNotNull(json.name,
                    "JSON record does not contain \"name\" required property.");
                Assert.IsNotNull(json.type,
                    "JSON record does not contain \"type\" required property.");
            }
        }
        [TestMethod]
        public void DynamicObjectResultValue_DynamicCollection_Should_Convert_To_IEnumerable() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousCollection() as JsonResult;
            dynamic jsonCollection = result.Value.AsDynamicObject();
            int count = 0;
            foreach (var value in jsonCollection) {
                count++;
            }
            //Assert
            Assert.IsTrue(count > 0);
        }
        [TestMethod]
        public void DynamicObjectResultValue_DynamicCollection_Index_at_0_Should_Not_be_Null() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousCollection() as JsonResult;
            dynamic jsonCollection = result.Value.AsDynamicObject();
            //Assert                
            Assert.IsNotNull(jsonCollection[0]);
        }
        [TestMethod]
        public void DynamicObjectResultValue_DynamicCollection_Should_Be_Indexable() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousCollection() as JsonResult;
            dynamic jsonCollection = result.Value.AsDynamicObject();
            //Assert
            for (var i = 0; i < jsonCollection.Count; i++) {
                var json = jsonCollection[i];
                Assert.IsNotNull(json);
                Assert.IsNotNull(json.id,
                   "JSON record does not contain \"id\" required property.");
                Assert.IsNotNull(json.name,
                    "JSON record does not contain \"name\" required property.");
                Assert.IsNotNull(json.type,
                    "JSON record does not contain \"type\" required property.");
            }
        }
        [TestMethod]
        public void DynamicObjectResultValue_DynamicCollection_Count_Should_Be_20() {
            //Arrange
            var controller = new MvcTestsController();
            //Act
            var result = controller.GetAnonymousCollection() as JsonResult;
            //Assert
            dynamic jsonCollection = result.Value.AsDynamicObject();
            Assert.AreEqual(20, jsonCollection.Count);
        }
    }
