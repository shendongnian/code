	public enum QuestionType
	{
		YesNo,
		Text,
		MultipleChoice
	}
	public class Survey
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public List<YesNoQuestion> YesNoQuestions { get; set; }
		public List<TextQuestion> TextQuestions { get; set; }
		public List<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
	}
	public abstract class Question
	{
		public int ID { get; set; }
		public string Text { get; set; }
		public QuestionType Type { get; set; }
	}
	public class YesNoQuestion : Question
	{
		public bool Answer { get; set; }
	}
	public class TextQuestion : Question
	{
		public string Answer { get; set; }
	}
	public class MultipleChoiceQuestion : Question
	{
		public int Answer { get; set; }
		public List<MultipleChoiceAnswer> PossibleAnswers { get; set; }
	}
	public class MultipleChoiceAnswer
	{
		public int ID { get; set; }
		public int QuestionID { get; set; }
		public string Text { get; set; }
	}
