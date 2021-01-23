        public const int A = 2;
        public const int B = 3;
        public const int C = 2;
        public static IEnumerable<object[]> GetTestCases
        {
            get
            {
                // 1st test case
                // This line will be in stack trace if this test will failed
                // So you can navigate from Test Explorer directly from StackTrace.
                // Also, you can debug only this test case, by setting a break point in lambda body - 'l()'
                Action<Action> runLambda = l => l();
                yield return new object[]
                {
                    A, B, 4,
                    runLambda
                };
                // 2nd test case
                runLambda = l => l();
                yield return new object[]
                {
                    A, C, 4,
                    runLambda
                };
                // ...other 100500 test cases...
            }
        }
        [Theory]
        [MemberData("GetTestCases")]
        public void TestMethod1(int operand1, int operand2, int expected, Action<Action> runLambda)
        {
            // pass whole assertions in a callback 
            runLambda(() =>
            {
                var actual = operand1 + operand2;
                Assert.Equal(actual, expected);
            });
        }
