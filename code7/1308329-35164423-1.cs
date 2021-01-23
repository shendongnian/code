    public interface IModel
    {
        object Value { get; }
    }
    public class Model<T> : IModel, IModel<T> 
    {
        public T Value { get; set; }
        object IModel.Value => Value;
    }
