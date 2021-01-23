    class Program
    {
        static void Main(string[] args)
        {           
            List<string> colorList = new List<string>();
            colorList.AddRange(new List<string>() {
                                      "1. Red",
                                      "2. Green",
                                      "3. Blue",
                                      "4. Yellow",
                                      "5. White",
                                      "6. Black",
                                      "7. Violet",
                                      "8. Brown",
                                      "9. Orange",
                                      "10. Pink"
            });
            Console.WriteLine("Traditional foreach loop\n");
            //start the stopwatch for "for" loop
            var sw = Stopwatch.StartNew();
            foreach (string color in colorList)
            {
                Console.WriteLine("{0}, Thread Id= {1}", color, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
            Console.WriteLine("Foreach loop execution time = {0} seconds\n", sw.Elapsed.TotalSeconds);
            //-------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine("Using Parallel.ForEach");
            //start the stopwatch for "Parallel.ForEach"
            sw = Stopwatch.StartNew();
            int index = 0;
            Parallel.ForEach(colorList, (color, state) =>
            {
                index++;
                if (index >= colorList.Count - 1)
                {
                    state.Stop();
                }
                Console.WriteLine("{0}, Thread Id= {1}", color, Thread.CurrentThread.ManagedThreadId);
                if (color == "2. Green")
                {
                    colorList.RemoveRange(3, 2);
                }
                Thread.Sleep(10);
            }
            );
            Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", sw.Elapsed.TotalSeconds);
            Console.Read();
        }
    }
