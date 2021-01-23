    public MultipleChoiceQuestion(McqType mcqType)
    {
       Question q;
       switch (mcqType) {
          case SingleAnswer:
             q = new MultipleChoiceQuestionSingle();
             break;
          case MultipleAnswers:
             q = new MultipleChoiceQuestionMultiple();
             break;
       }
    }
