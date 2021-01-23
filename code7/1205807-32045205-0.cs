    static void Main(string[] args)
            {
                List<string> questions = new List<string>(){ "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56" };
                XDocument xmldata = XDocument.Load("C:\\Users\\Test\\test.xml");
                foreach (var courseNode in xmldata.Root.Descendants("course"))
                {
                    string course = (string) courseNode.Attribute("srcid").Value;
                    string instructor = (string) courseNode.Element("instructor").Attribute("srcid").Value;
    				int evaluationCount = 0;
                    foreach (var evaluationNode in courseNode.Descendants("evaluation"))
                    {
                        var eval = from answer in evaluationNode.Descendants("response")
                                         where questions.Contains(answer.Attribute("questionId").Value)
                                         select answer;
                        string output = course + instructor;
                        foreach (string answer in eval)
                            output += answer;
                        Console.Write(output + "\r\n");
    					++evaluationCount;
                    }
    				if (evaluationCount == 0)
    				{
    					Console.WriteLine(course + instructor);
    				}
                }
                Console.ReadLine(); 
            }
