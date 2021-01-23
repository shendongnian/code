    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void MyTestMethod() {
            //Arrange
            var data = getStates();
            //Act
            var result = data.getIntoDropDownState("StateName", "StateID");
            //Assert
            Assert.IsNotNull(result);
            var first = result.First();
            Assert.AreEqual(data[0].StateName, first.Text);
            Assert.AreEqual(data[0].StateID, first.Value);
        }
        public List<State> getStates() {
            return new List<State>(){
                 new State{StateID="1",StateName="Tamil Nadu"},
                 new State{StateID="2",StateName="Assam"},
                 new State{StateID="3",StateName="Andra"},
                 new State{StateID="4",StateName="bihar"},
                 new State{StateID="5",StateName="Bengal"},            
            };
        }
        public class State {
            public string StateID { get; set; }
            public string StateName { get; set; }
        }
    }
