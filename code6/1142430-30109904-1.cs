    private int TotalQuestions(Category category, Dictionary<Category, int> counts)
            {
                if (!counts.ContainsKey(category))
                {
                    counts.Add(category, category.Questions.Count);
                }
    
                foreach (var innerCategory in category.Categories)
                {
                    counts[category] += TotalQuestions(innerCategory, counts);
                }
    
                return counts[category];
            }
