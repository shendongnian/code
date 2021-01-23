     [TestMethod]
            public void Log_Error_LogsToStdErr()
            {
                var logger = SetupFakeLogger_Works();
    
                logger.Log("text to log", true);
    
                Isolate.Verify.WasCalledWithAnyArguments(() => logger.LogToFile(""));
                //Isolate.Verify.WasCalledWithAnyArguments(() => Console.Error.WriteLine(""));
            }
    
            private static WrapperLogger SetupFakeLogger_Works()
            {
                var textWriter = Isolate.Fake.Instance<TextWriter>();
                Console.SetOut(textWriter);
    
                return Isolate.Fake.Instance<WrapperLogger>(Members.CallOriginal, ConstructorWillBe.Called, "dir", "file.log");
            }
