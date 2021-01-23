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
And when using it you have to add a parameter to your test function
[Theory(DisplayName = "It should have the expected length")]
[Repeat(10)]
public void It_should_have_the_expected_length(int iterationNumber)
{
...
}
