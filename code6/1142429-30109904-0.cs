     public int TotalQuestions(Category category)
            {
                var totalQuestions = category.Questions.Count;
                foreach (var innerCategory in category.Categories)
                {
                    totalQuestions += TotalQuestions(innerCategory);
                }
                return totalQuestions;
    
                //OR
                //return category.Questions.Count + category.Categories.Sum(innerCategory => TotalQuestions(innerCategory));
            }
