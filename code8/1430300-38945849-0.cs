    IEnumerator MessageOuter() {
        Console.WriteLine("outer 1");
        var inner = MessageInner();
        Console.WriteLine("outer 2");
        return inner;
    }
    IEnumerator MessageInner() {
        Console.WriteLine("inner 1");
        yield return new WaitForSeconds(1);
        Console.WriteLine("inner 2");
        yield return new WaitForSeconds(1);
        Console.WriteLine("inner 3");
    }
    void Start() {
        Console.WriteLine("start 1");
        var outer = MessageOuter();
        Console.WriteLine("start 2");
        StartCoroutine(outer);
        Console.WriteLine("start 3");
    }
