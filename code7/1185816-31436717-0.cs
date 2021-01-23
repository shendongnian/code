    public interface ICloneable<T>
    {
        T Clone();
        Guid CloneId {get; set;}
    }
