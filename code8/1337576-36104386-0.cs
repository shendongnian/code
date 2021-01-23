    public class Question<T> where T : Entity
    {
        public static Question<T> Create()
        {
            return new Question<T>
            {
                Choice = Choice<T>.Create()
            };
        }
        private Choice<T> Choice { get; set; }
    }
    public class Choice<T> where T : Entity
    {
        public static Choice<T> Create()
        {
            return new Choice<T>();
        }
    }
    public abstract class Entity
    {
    }
