    public static class Question {
        public static Question<T> Create<T>(Choice<T> choice) {
            return Question<T>.Create(choice);
        }
    }
    ...
    Question<Entity> question = Question.Create(Choice<Entity>.Create());
