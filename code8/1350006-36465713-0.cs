    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var reader = new StreamReader(stream))
    	using (var writer = new StreamWriter(stream))
    	using (var csv = new CsvReader(reader))
    	{
    		writer.WriteLine("Org Defined ID,Username,FirstName,LastName,Attempt #,Attempt Start,Attempt End,Section #,Q #,Q Type,Q Title,Q Text,Bonus?,Difficulty,Answer,Answer Match,Score,Out Of");
    		writer.WriteLine(", testomalley, Test, O'Malley,1,2/3/2016 15:24,2/3/2016 15:28,,1,LA,Q(1) 1- 5 Part 1,\"Scenario 1 for Questions 1 through 5. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.  Part 1 - Sed ut perspiciatis unde omnis iste natus error sit voluptatem.\",FALSE,1,Here is my answer o grader. Isn't it brilliant ?,, 0, 2");
    		writer.Flush();
    		stream.Position = 0;
    		
    		csv.Configuration.RegisterClassMap<ExamMap>();
    		csv.GetRecords<Exam>().ToList().Dump();
    	}
    }
    
    public class Exam
    {
    	public int? OD_ID { get; set; }
    	public string Username { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int AttemptNo { get; set; }
    	public DateTime AttemptStart { get; set; }
    	public DateTime AttemptEnd { get; set; }
    	public int? SectionNo { get; set; }
    	public int QuestionNo { get; set; }
    	public string QuestionType { get; set; }
    	public string QuestionTitle { get; set; }
    	public string Questiontext { get; set; }
    	public string Bonus { get; set; }
    	public int Difficulty { get; set; }
    	public string Answer { get; set; }
    	public string AnswerMatch { get; set; }
    	public int Score { get; set; }
    	public int OutOf { get; set; }
    }
    
    public sealed class ExamMap : CsvHelper.Configuration.CsvClassMap<Exam>
    {
    	public ExamMap()
    	{
    		Map(m => m.OD_ID).Name("Org Defined ID");
    		Map(m => m.Username).Name("Username");
    		Map(m => m.FirstName).Name("FirstName");
    		Map(m => m.LastName).Name("LastName");
    		Map(m => m.AttemptNo).Name("Attempt #");
    		Map(m => m.AttemptStart).Name("Attempt Start");
    		Map(m => m.AttemptEnd).Name("Attempt End");
    		Map(m => m.SectionNo).Name("Section #");
    		Map(m => m.QuestionNo).Name("Q #");
    		Map(m => m.QuestionType).Name("Q Type");
    		Map(m => m.QuestionTitle).Name("Q Title");
    		Map(m => m.Questiontext).Name("Q Text");
    		Map(m => m.Bonus).Name("Bonus?").TypeConverterOption(true, "TRUE").TypeConverterOption(false, "FALSE");
    		Map(m => m.Difficulty).Name("Difficulty");
    		Map(m => m.Answer).Name("Answer");
    		Map(m => m.AnswerMatch).Name("Answer Match");
    		Map(m => m.Score).Name("Score");
    		Map(m => m.OutOf).Name("Out Of");
    	}
    }
