    using System;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace MatrixMultiplication
    {
        class Matrix
        {
            public int Row { get; set; }
            public int Column { get; set; }
            double[,] arr;
            public static Mutex mutex = new Mutex();
    
            Matrix() { }
            public Matrix(int row, int column)
            {
                Row = row;
                Column = column;
                arr = new double[row, column];
            }
            public double[] GetColumn(int i)
            {
                double[] res = new double[Row];
                for (int j = 0; j < Row; j++)
                    res[j] = arr[j, i];
                return res;
            }
            public double[] GetRow(int i)
            {
                double[] res = new double[Column];
                for (int j = 0; j < Column; j++)
                    res[j] = arr[i, j];
                return res;
            }
            public double this[int i, int j]
            {
                get { return arr[i, j]; }
                set { arr[i, j] = value; }
            }
            public Matrix RandomValues()
            {
                Random rnd = new Random();
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Column; j++)
                        arr[i, j] = rnd.Next(10);
                return this;
            }
    
            public void Print()
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                        Console.Write(arr[i, j] + " ");
                    Console.WriteLine();
                }
            }
    
            public static Matrix operator *(Matrix a, Matrix b)
            {
                Matrix result = new Matrix(a.Row, b.Column);
                List<Thread> threads = new List<Thread>();
                for (int i = 0; i < a.Row; i++)
                {
                    int tempi = i;
                    Thread thread = new Thread(() => VectorMult(tempi, a, b, result));
                    thread.Start();
                    threads.Add(thread);
                }
                foreach (Thread t in threads)
                    t.Join();
                return result;
            }
    
            public static void VectorMult(int tmpi, Matrix a, Matrix b, Matrix result)
            {
                mutex.WaitOne();
                int i = tmpi;
                double[] x = a.GetRow(i);
                for (int j = 0; j < b.Column; j++)
                {
                    double[] y = b.GetColumn(j);
                    for (int k = 0; k < x.Length; k++)
                        result[i, j] += x[k] * y[k];
                }
                mutex.ReleaseMutex();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("n=");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("m=");
                int m = int.Parse(Console.ReadLine());
                Console.WriteLine("k=");
                int k = int.Parse(Console.ReadLine());
                Matrix A = new Matrix(n, m).RandomValues();
                Matrix B = new Matrix(m, k).RandomValues();
                A.Print();
                Console.WriteLine(new String('-', 20));
                B.Print();
                Console.WriteLine(new String('-', 20));
                Matrix C = A * B;
                C.Print();
                Console.ReadLine();
            }
        }
    }
