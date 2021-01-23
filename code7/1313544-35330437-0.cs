            List<Question> questions = new List<Question>
            {
                new Question { Id = 1, Name = "What?" },
                new Question { Id = 2, Name = "How?" },
                new Question { Id = 3, Name = "When?" },
                new Question { Id = 4, Name = "Where?" },
            };
            var q = (from c in questions select c);
            Random rdm = new Random();
            int randomRow = rdm.Next(1, q.Count());
            var result = q.Where(x => x.Id == randomRow).Single();
            Console.WriteLine(result.Name);
