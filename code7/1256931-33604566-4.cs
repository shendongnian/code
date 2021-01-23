    void main(string[] args]) {
		Question qes = new Question();
		ques.Ask = "How old am I?";
		ques.Answer = new string[]{ "20" };
		ques.CorrectAnswerIndex = 0;
		string json = Converter.ObjctToJson<Question>(qes);
		Console.WriteLine(json);
		Question clone = Converter.JsonToObject<Object>(json);
		Console.WriteLine(clone);
	}
