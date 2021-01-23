    class Program
    {
        static void Main(string[] args)
        {
            float var = 3.14f;
            StartCoroutine(test(var), out var);
        }
        static IEnumerator test(float value)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(value);
                yield return value + 1;
            }
        }
        static void StartCoroutine(IEnumerator test, out float update)
        {
            update = 0;
            while (test.MoveNext())
            {
                update++;
                Console.WriteLine("Executing..." + update);
            }
        }
    }
