    private ClassUnderTest CreateClassUnderTest(
        ILogger logger = null, IMailSender mailSender = null, IEventPublisher publisher = null)
    {
        return new ClassUnderTest(
            logger ?? new FakeLogger(),
            mailSender ?? new FakeMailer(),
            publisher ?? new FakePublisher());
    }
