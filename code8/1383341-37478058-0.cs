     List<QuestionDto> dtoQList = _db.Questions.Where(x => (x.Title.Contains(temp) || x.Message.Contains(temp) || (x.User.FirstName + " " + x.User.LastName).Contains(temp) || x.User.LastName.Contains(temp)) && (categoryId == null || x.Category.CategoryId == categoryId))
            .Select(question => new QuestionDto
            {
                QuestionId = question.QuestionId,
                Votes = question.Votes,
                Title = question.Title,
                Message = question.Message,
                CategoryName = question.Category.Name,
                EditDate = question.EditDate,
                DateOfCreation = question.DateOfCreation,
                User = new UserDto { UserId = question.User.Id, FirstName = question.User.FirstName, LastName = question.User.LastName, ImageFile = question.User.ImageFile },
                Tags = question.Tags.Select(x => x.Tag).ToList()
            }).ToList();
            var questionDictionaryMatchings = new Dictionary<int, int>();
            foreach(var question in dtoQList)
            {
                var titleSplited = question.Title.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var messageSplited = question.Message.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var firstNameSplited = question.User.FirstName.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var lastNameSplited = question.User.LastName.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var titleSplitedQuery = from word in titleSplited
                                 where word.ToLowerInvariant() == temp.ToLowerInvariant()
                                 select word;
                int wordCountTitle = titleSplitedQuery.Count();
                var messageSplitedQuery = from word in messageSplited
                                          where word.ToLowerInvariant() == temp.ToLowerInvariant()
                                        select word;
                int wordCountMessage = messageSplitedQuery.Count();
                var firstNameSplitedQuery = from word in firstNameSplited
                                        where word.ToLowerInvariant() == temp.ToLowerInvariant()
                                        select word;
                int wordCountFirstName = firstNameSplitedQuery.Count();
                var lastNameSplitedQuery = from word in lastNameSplited
                                        where word.ToLowerInvariant() == temp.ToLowerInvariant()
                                        select word;
                int wordCountLastName = lastNameSplitedQuery.Count();
                questionDictionaryMatchings.Add(question.QuestionId, wordCountTitle + wordCountMessage + wordCountFirstName + wordCountLastName);
            }
