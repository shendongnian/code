    public interface IInterviewQuestion
    {
        int Method(IQuestionInput qParams);
        int Alternative(IQuestionInput qParams);
        bool Test();
    }
