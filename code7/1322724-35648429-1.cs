    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int n = 20000000;
                int[] a = new int[n];
                var rng = new Random(937525);
                for (int i = 0; i < n; ++i)
                    a[i] = rng.Next();
                var b = a.ToArray();
                var d = a.ToArray();
                var sw = new Stopwatch();
                sw.Restart();
                var c = a.OrderBy(x => x).ToArray(); // Need ToArray(), otherwise it does nothing.
                Console.WriteLine("LINQ OrderBy() took " + sw.Elapsed);
                sw.Restart();
                var e = a.AsParallel().OrderBy(x => x).ToArray(); // Need ToArray(), otherwise it does nothing.
                Console.WriteLine("PLINQ OrderBy() took " + sw.Elapsed);
                sw.Restart();
                Array.Sort(d);
                Console.WriteLine("Array.Sort() took " + sw.Elapsed);
                sw.Restart();
                QuicksortSequential(a, 0, a.Length-1);
                Console.WriteLine("Sequential took " + sw.Elapsed);
                sw.Restart();
                QuicksortParallelOptimised(b, 0, b.Length-1);
                Console.WriteLine("Parallel took " + sw.Elapsed);
                // Verify that our sort implementation is actually correct!
                Trace.Assert(a.SequenceEqual(c));
                Trace.Assert(b.SequenceEqual(c));
            }
            static void QuicksortSequential<T>(T[] arr, int left, int right)
            where T : IComparable<T>
            {
                if (right > left)
                {
                    int pivot = Partition(arr, left, right);
                    QuicksortSequential(arr, left, pivot - 1);
                    QuicksortSequential(arr, pivot + 1, right);
                }
            }
            static void QuicksortParallelOptimised<T>(T[] arr, int left, int right)
            where T : IComparable<T>
            {
                const int SEQUENTIAL_THRESHOLD = 2048;
                if (right > left)
                {
                    if (right - left < SEQUENTIAL_THRESHOLD)
                    {
                        QuicksortSequential(arr, left, right);
                    }
                    else
                    {
                        int pivot = Partition(arr, left, right);
                        Parallel.Invoke(
                            () => QuicksortParallelOptimised(arr, left, pivot - 1),
                            () => QuicksortParallelOptimised(arr, pivot + 1, right));
                    }
                }
            }
            static int Partition<T>(T[] arr, int low, int high) where T : IComparable<T>
            {
                int pivotPos = (high + low) / 2;
                T pivot = arr[pivotPos];
                Swap(arr, low, pivotPos);
                int left = low;
                for (int i = low + 1; i <= high; i++)
                {
                    if (arr[i].CompareTo(pivot) < 0)
                    {
                        left++;
                        Swap(arr, i, left);
                    }
                }
                Swap(arr, low, left);
                return left;
            }
            static void Swap<T>(T[] arr, int i, int j)
            {
                T tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }
    }
