    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class ConcurrentTasks
    {
        private static char[] m_out;
        private static int m_index = -1;
        
        public static void Main(String[] args)
        {
            var iterations = 5000;
            m_out = new char[iterations * 2];
            var task1 = Task.Run(()=>DemoTask(iterations, '+'));
            var task2 = Task.Run(()=>DemoTask(iterations, '-'));
            var res1 = task1.Result;
            var res2 = task2.Result;
            
            for (int i = 0; i < m_out.Length; i++)
            {
                Console.Write(m_out[i]);
            }
            
            Console.WriteLine("\nResults:");
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
        
        private static String DemoTask(int iterations, char label)
        {
            for (int i = 0; i < iterations; i++)
            {
                int index = Interlocked.Increment(ref m_index);
                m_out[index] = label;
            }
            
            return label + " result";
        }
    }
