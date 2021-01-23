    const int size = 10; // How many questions you want to be returned.
    public IEnumerable<Questions> GetQuestions(int page) 
    {
        return questions.Skip(size * page).Take(size);
    }
