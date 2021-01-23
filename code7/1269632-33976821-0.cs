	[TestFixture]
	public class MessageTests
	{
		static Case[] ValidCases = {
			new Case ("S...", typeof(Sms_Message)),
			new Case ("T...", typeof(Tweet)),
			new Case ("E...", typeof(SIREmail)),
			new Case ("E...", typeof(StandardEmail))
		};
		[Test]
		[TestCaseSource("ValidCases")]
		public void Create_ShouldCreate_WhenValidSource(Case currentCase)
		{
			// when
			Message created = TargetClass.create (currentCase.Body);
			// then
			Assert.That (created.GetType (), Is.InstanceOf (currentCase.ExpectedResultType));
		}
			
		public class Case
		{
			public Case(string body, Type expectedResultType)
			{
				Body = body;
				ExpectedResultType = expectedResultType;
			}
			public string Body { get; private set; }
			public Type ExpectedResultType { get; private set; }
		}
	}
