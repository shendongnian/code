        [Test]
        public void PerformTest()
        {
            List<object> objs = new List<object>();
            Exception ex = new Exception("Access is denied.");
            objs.Add(true);
            AuthorizeCompletedEventArgs incorrectPasswordArgs = new AuthorizeCompletedEventArgs(null, ex, false, null);
            AuthorizeCompletedEventArgs correctPasswordArgs = new AuthorizeCompletedEventArgs(objs.ToArray(), null, false, null);
            Moq.Mock<IMyService> client = new Mock<IMyService>();
            client .Setup(t => t.AuthorizeAsync(It.Is<string>((s) => s == "correct"), It.Is<string>((s) => s == "correct"))).Callback(() =>
            {
                client.Raise(t => t.AuthorizeCompleted += null, correctPasswordArgs);
            });
            client.Setup(t => t.AuthorizeAsync(It.IsAny<string>(), It.IsAny<string>())).Callback(() =>
            {
                client.Raise(t => t.AuthorizeCompleted += null, incorrectPasswordArgs);
            });
            var ViewModel = new MyClass(client.Object);
            ViewModel.UserName = "correct";
            ViewModel.Password = "correct";
            ViewModel.SignIn.Execute();
        }
