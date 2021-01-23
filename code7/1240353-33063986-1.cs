    const int size = 10; // How many questions you want to be returned.
    public IEnumerable<QuestionView> GetQuestions(int page) 
    {
        return questions.Skip(size * page).Take(size);
    }
