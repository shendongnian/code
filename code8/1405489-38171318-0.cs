    public class Evaluate
    {
        public Stopwatch Timer { get; private set; }
    
        public Evaluate()
        {
            this.Timer = new Stopwatch();
        }
    
        public static long Elapsed(Action expression)
        {
            Stopwatch timer = Stopwatch.StartNew();
            expression();
            return timer.ElapsedMilliseconds;
        }
    
        public static T ElapsedWithReturn<T>(Func<T> expression, ref long elapsed)
        {
            Stopwatch timer = Stopwatch.StartNew();
            T result = expression();
            elapsed = timer.ElapsedMilliseconds;
            return result;
        }
    
        public T IncrementTimer<T>(Func<T> expression)
        {
            this.Timer.Start();
            T result = expression();
            this.Timer.Stop();
            return result;
        }
    }
    
    class Program
    {
        public static int Multiply(int x, int y)
        {
            int result = x * y;
            return result;
        }
    
        static void Main()
        {
            int result;
            long elapsed;
    
            // evaluate a bunch of code using static evaluate function.
            elapsed = Evaluate.Elapsed(() =>
            {
                result = Multiply(1, 2);
                result = Multiply(2, 3);
                result = Multiply(3, 4);
            });
    
            // evaluate with specific return value, setting elapsed by reference
            result = Evaluate.ElapsedWithReturn(() => Multiply(1, 2), ref elapsed);
    
            // evaluate with specific return value, getting elapsed over time from class
            Evaluate evaluate = new Evaluate();
            result = evaluate.IncrementTimer(() => Multiply(1, 2));
            result = evaluate.IncrementTimer(() => Multiply(2, 3));
            elapsed = evaluate.Timer.ElapsedMilliseconds;
        }
    }
