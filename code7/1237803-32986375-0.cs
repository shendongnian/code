	protected override IConnectableObservable<ITestResult<ITestOutput<double, double>, ITestLimit<double>>> ProcessOutput(
		IConnectableObservable<ITestOutput<double, double>> output, InputVerificationTestCase testCase)
	{
		var source = output.RefCount();
		return
			source
				.Select(o =>
				{
					var limits = GenerateDcAccuracyLimits.CalculateAbsoluteLimits(o.Input, testCase.FullScaleRange, testCase.Limits);
					return new TestResult<ITestOutput<double, double>, ITestLimit<double>>
					{
						Component = "Variable Gain Module Input",
						Description = "Measurement Accuracy",
						Limits = limits,
						Output = o,
						Passed = _validationService.Validate(o.Result, limits)
					};
				})
				.Merge(
					source
						.ToArray()
						.Select(arr => GetGainErrorResult(ComputeErrorFit(arr, testCase).Item2, testCase)))
				.Publish();
	}
