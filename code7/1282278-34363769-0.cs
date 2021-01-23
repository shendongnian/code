    namespace ConsoleApplication
    {
        using System;
        using Moq;
        using NUnit.Framework;
        public class MoqCallbackTest
        {
            [Test]
            public void TestMethod()
            {
                Mock<IAnotherService> mockAnotherService = new Mock<IAnotherService>();
                Mock<IUserDialogs> mockUserDialogs = new Mock<IUserDialogs>();
                mockUserDialogs.Setup(s => s.Confirm(It.IsAny<ConfirmConfig>())).Callback((ConfirmConfig confirmConfig) => confirmConfig.OnConfirm(true));
                SystemUnderTest systemUnderTest = new SystemUnderTest(mockUserDialogs.Object, mockAnotherService.Object);
                systemUnderTest.ViewModelMethod();
                mockAnotherService.Verify(p => p.Method(), Times.Never());
            }
            public interface IAnotherService
            {
                void Method();
            }
            public interface IUserDialogs
            {
                void Confirm(ConfirmConfig config);
            }
            public class ConfirmConfig
            {
                public Action<bool> OnConfirm { get; set; }
            }
            public class SystemUnderTest
            {
                readonly IAnotherService anotherService;
                readonly IUserDialogs userDialogs;
                public SystemUnderTest(IUserDialogs userDialogs, IAnotherService anotherService)
                {
                    this.userDialogs = userDialogs;
                    this.anotherService = anotherService;
                }
                public void ViewModelMethod()
                {
                    userDialogs.Confirm(new ConfirmConfig { OnConfirm = result =>
                    {
                        if (result)
                            anotherService.Method();
                    } });
                }
            }
        }
    }
