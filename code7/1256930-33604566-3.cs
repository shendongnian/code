	namespace Test
	{
		[DataContract]
		public class Question
		{
			[DataMember(IsRequired=true)]
			public string Ask;
			[DataMember(IsRequired=true)]
			[DataMember]
			public string[] Answers;
			[DataMember(IsRequired=true)]
			[DataMember]
			public byte CorrectAnswerIndex;
			[DataMember] // [DataMember(IsRequired=false)]
			public double Mark;
		}
	}
