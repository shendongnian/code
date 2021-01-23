       var class1 = new Class1();
       class1.ExecuteCase(1);
       class1.ExecuteCase(2);
    
        public class Class1
        {
            private List<string> T = new List<string>();
    
            public void ExecuteCase(int caseNumber)
            {
                switch (caseNumber)
                {
                    case 1:
                        var question = "question1";
                        T.Add(question);
                        break;
    
                    case 2:
                        foreach (string declare in T)
                        {
                            Console.WriteLine(declare);
                        }
                        break;
                }
            }
        }
