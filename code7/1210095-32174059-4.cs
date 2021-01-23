    [TestMethod]
    public void TestGetAllMailEntries2() {
       var mockSearcher = new Mock<IDirectorySearcher>();
       mockSearcher
       .Setup(s => s.FindAll())
       .Returns(new[] {
          ActiveDirectoryUser.Create(new Guid(), "Name", "EmailAddress")
       });
       var queryer = new ActiveDirectoryQueryer(mockSearcher.Object);
       queryer.GetAllMailEntries();
       Assert.AreEqual(1, queryer.MailEntries.Count());
       var entry = queryer.MailEntries.Single();
       Assert.AreEqual("Name", entry.Name);
       Assert.AreEqual("EmailAddress", entry.EmailAddress);
    }
