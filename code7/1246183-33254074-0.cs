    [TestMethod]
        public void Publish_Status_If_Nothing_Receieved()
        {
            //Arrange
            var scheduler = new TestScheduler();
            var statusObserver = scheduler.CreateObserver<Unit>();
            var updateStream = scheduler.CreateColdObservable(OnNext(100, 1), OnNext(200, 2), OnNext(600, 3),
                OnNext(700, 4));
            var waitTime = TimeSpan.FromTicks(200);
            //Act
            updateStream.Throttle(waitTime, scheduler)
                .Select(_ => Unit.Default)
                .Subscribe(statusObserver);
            //Verify no status received
            scheduler.AdvanceTo(100);
            Assert.AreEqual(0, statusObserver.Messages.Count);
            //Verify no status received
            scheduler.AdvanceTo(200);
            Assert.AreEqual(0, statusObserver.Messages.Count);
            
            //Assert status received
            scheduler.AdvanceTo(400);
            statusObserver.Messages.AssertEqual(OnNext(400, Unit.Default));
            //Verify no more status received
            scheduler.AdvanceTo(700);
            statusObserver.Messages.AssertEqual(OnNext(400, Unit.Default));
        }
