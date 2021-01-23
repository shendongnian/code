        [TestMethod]
        public void Test_Service_When_Passing_String_And_ActionDelegate()
        {
            var actionImplement = new Mock<ActionImplement>();
            actionImplement.Setup(m => m.Action(It.IsAny<string>()));
            var mock = new Mock<IRepeater>();
            mock.Setup(m => m.Each(It.IsAny<string>(), actionImplement.Object.Action));
            
            var srv = new Service(mock.Object);
            srv.Foo("aa",actionImplement.Object.Action);
            
            
            mock.Verify(ai => ai.Each("aa", actionImplement.Object.Action));
        }
