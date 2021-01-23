                var questions = new List<List<string>> { 
                    new List<string>{"aaa", "bbb", "ccc"},
                    new List<string>{"aaa", "bbb", "ddd"},
                };
                var groupOfQuestions = new List<string>() { "ddd" };
                var questionMatches = new List<List<string>>();
    
                foreach (List<string> q in questions)
                {
                    if (!groupOfQuestions.Except(q).Any()) //I also tried without '!'
                    {
                        questionMatches.Add(groupOfQuestions);
                    }
                }
