    static void TypeLine(string line) {
        for (int i = 0; i < line.Length; i++) {
            Console.Write(line[i]);
            System.Threading.Thread.Sleep(150); // Sleep for 150 milliseconds
        }
    }
