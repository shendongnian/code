    class Disposable : IDisposable {
        public void Dispose() {
            Console.WriteLine("Disposed!");
        }
    }
    IEnumerable<int> CreateEnumerable() {
        int i = 0;
        using (var d = new Disposable()) {
           while (true) yield return ++i;
        }
    }
    void UseEnumerable() {
        foreach (int i in CreateEnumerable()) {
            Console.WriteLine(i);
            if (i == 10) break;
        }
    }
