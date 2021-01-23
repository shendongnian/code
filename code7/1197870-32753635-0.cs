     static void Main(string[] args)
            {
                Playback.Initialize();
                CodedUITests.CodedUITTest test = new CodedUITests.CodedUITTest();
                test.Testmethod1();
                Playback.Cleanup();
            }
