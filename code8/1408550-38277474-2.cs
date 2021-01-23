            var tests = new List<Action>
            (
                Login,
                CreateSomeRecord,
                EditSomeRecord,
                DeleteSomeRecord
            );
            foreach (var test in tests)
            {
                var testDetails = RunTest(test);
                RptRowValueAdd(ReportDt, "", testDetails.TestName, testDetails.ResultDescription, testDetails.TestResult.ToString(), testDetails.ElapsedTime);
            }
