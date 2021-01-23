public sealed class RepeatAttribute : Xunit.Sdk.DataAttribute
{
	private readonly int count;
	public RepeatAttribute(int count)
	{
		if (count < 1)
		{
			throw new System.ArgumentOutOfRangeException(
				paramName: nameof(count),
				message: "Repeat count must be greater than 0."
				);
		}
		this.count = count;
	}
	public override System.Collections.Generic.IEnumerable<object[]> GetData(System.Reflection.MethodInfo testMethod)
	{
		foreach (var iterationNumber in Enumerable.Range(start: 1, count: this.count))
		{
			yield return new object[] { iterationNumber };
		}
	}
}
While on the previous example the Enumerable.Repeat was being used it would only run the test 1 time, somehow xUnit is not repeating the test. Probably something they have changed a while ago.
By changing to a `foreach` loop we are able to repeat each test but we also provide the "iteration number".
When using it on the test function you have to add a parameter to your test function and decorate it as a `Theory` as shown here:
[Theory(DisplayName = "It should work")]
[Repeat(10)]
public void It_should_work(int iterationNumber)
{
...
}
This works for xUnit 2.4.0.
I've created a NuGet [package][1] to use this in case anyone is interested.
  [1]: https://www.nuget.org/packages/Xunit.Repeat/
