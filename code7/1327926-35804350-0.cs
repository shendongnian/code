        static void Main(string[] args) {
            ShowCallerLine(); // hello!
            ShowCallerLine(); // goodybye!
        }
        static void ShowCallerLine() {
            var frame = new StackFrame(1, true);
            var lineNumber = frame.GetFileLineNumber();
            var fileName = frame.GetFileName();
            var line = File.ReadLines(fileName).ElementAt(lineNumber - 1);
            Console.WriteLine(line);
        }
