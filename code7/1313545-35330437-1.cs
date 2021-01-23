            List<Question> questions = new List<Question>
            {
                new Question { Id = 10, Name = "What?" },
                new Question { Id = 12, Name = "How?" },
                new Question { Id = 32, Name = "When?" },
                new Question { Id = 41, Name = "Where?" },
            };
            var q = (from c in questions select c);
            
            int i = 1;
            Dictionary<int, int> questionKeys = new Dictionary<int, int>();
            foreach (var item in questions)
            {
                questionKeys.Add(i, item.Id);
                i++;
            }
            Random rdm = new Random();
            int randomRow = rdm.Next(1, q.Count());
            var questionId = questionKeys.Where(x => x.Key == randomRow).Select(x => x.Value).Single();
            var result = q.Where(x => x.Id == questionId).Single();
            Console.WriteLine(result.Name);
