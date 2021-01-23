        [Test]
        public void WhenReceiveASimpleMessageActorShouldSendSuperMessageToHimself()
        {
            var testProbe = this.CreateTestProbe();
            var props = Props.Create<MySuperActor>(testProbe);
            var sut = this.Sys.ActorOf(props);
            sut.Tell(new MySuperActorMessage());
            testProbe.ExpectMsg<AnotherActorMessage>();
        }
