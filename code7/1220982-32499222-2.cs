    class _Nullable {}
   
    struct _Nullable<T> {}
    
    class Program
    {
        static void Main()
        {
           string a = "";
           Console.Write(a is _Nullable);
        }
    }
