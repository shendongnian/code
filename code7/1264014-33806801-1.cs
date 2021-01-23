    public class Publisher
    {
        // Instance
        private static readonly Publisher instance = new Publisher();
        public event EventHandler SendResponse;
        public static Publisher Instance
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// Private constructor
        /// </summary>
        private Publisher()
        {
        }
        public void Send()
        {
            // proof is subscipted
            if (this.SendResponse != null)
            {
                // Pass this
                this.SendResponse(this, EventArgs.Empty);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var copy = Publisher.Instance;
            copy.SendResponse += Copy_SendResponse;
            var copy2 = Publisher.Instance;
            copy2.Send();
            Console.ReadLine();
        }
        /// <summary>
        /// Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Copy_SendResponse(object sender, EventArgs e)
        {
            Console.WriteLine("It works!");
        }
    }
