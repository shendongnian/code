    class A
    {
        public int data;
    }
    class B : A { }
    class C : A { }
    class D : A { }
    interface IG<out T>
    {
        T field { get; }
    }
    class G<T> : IG<T>
    {
        public T field { get; set; }
    }
