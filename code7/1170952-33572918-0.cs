    public class ArrayObjectValidator<T>
    {
    public ArrayObjectValidator(T[] array)
    {
        this.array = array;
    }
    private T[] array { get; set; }
    public bool ValidateIndex(int index)
    {
        bool result = false;
        if (array != null && array.Length > 0)
        {
            result = CheckItemAt(index);
        }
        return result;
    }
    private bool CheckItemAt(int index)
    {
        return index >= 0 && index < array.Length && NullControl(index);
    }
    private bool NullControl(int index)
    {
        return array[index] != null && array[index] is T;
    }
    }
