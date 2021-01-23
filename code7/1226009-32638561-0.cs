    public class Program : GameWindow {
        private static void Main(string[] args) {
            Program display = null;
            var task = new Thread(() => {
                display = new Program();
                display.Run();
            });
            task.Start();
            while (display == null)
                Thread.Yield(); // wait a bit for another thread to init variable if necessary
            while (true)
            {
                Console.Write("> ");
                var response = Console.ReadLine();
                //communicate with the display object asynchronously
                display.Title = response;
            }
        }
    }
