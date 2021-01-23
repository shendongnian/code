    // Setup
    Mock<ExpiryNotifier> target = new Mock<ExpiryNotifier>();
    Mock<MailServiceWrapper> mailMock = new Mock<MailServiceWrapper>();
    target.Setup(t => t.getMailService()).Returns(mailMock.Object);
    
    // Act
    target.Object.notify();
    
    // Assert/Verify
    mailMock.Verify(
                m => m.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>(),
                    It.IsAny<string[]>(),
                    It.IsAny<string[]>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()
                ), 
                Times.Exactly(1)
            );
