    public class LimitedSizeStack<T>
    {
        private T[] items;
        private int top;
        private int count;
        public LimitedSizeStack(int size)
        {
            items = new T[size];
            top = size - 1;
            count = 0;
        }
        public bool IsEmpty { get { return count == 0; } }
        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("Stack is empty");
            return items[top];
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new Exception("Stack is empty");
            count--;
            var result = items[top];
            top--;
            if (top < 0)
                top += items.Length;
            return result;
        }
        public void Push(T value)
        {
            top++;
            if (top >= items.Length)
                top -= items.Length;
            items[top] = value;
            if (count < items.Length)
                count++;
        }
    }
