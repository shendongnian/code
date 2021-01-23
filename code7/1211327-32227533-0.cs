       using (var mock = AutoMock.GetLoose())
        {
            var issues = new List<Issue>();
            issues.Add(new Issue { Organization = "org", Repository = "repo", Number = 1 });
            issues.Add(new Issue { Organization = "org", Repository = "repo", Number = 2 });
            var numKeys = 0;
            mock.Mock<IStorageService>()
                .Setup(myMock => myMock.GetBatchIssues(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IList<string>>()))
                .Callback((string org, string repo, IList<string> keys) => numKeys = keys.Count)
                .Returns(issues);
            var sut = mock.Create<IssueReceiveService>();
            var check = await sut.CheckInStorage("org", "repo", issues);
            Assert.AreEqual(issues.Count, numKeys);
        }
