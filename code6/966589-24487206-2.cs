    internal class Program
    {
        private static void Main(string[] args)
        {
            var telephone = new Telephone();
            Console.WriteLine(telephone.Name);
            telephone.OutboundCall("+1 234 567");
            Console.WriteLine("Am I a Telephone?                 {0}", telephone is Telephone);
            Console.WriteLine("Am I a MP3?                       {0}", telephone is MediaPlayer3);
            Console.WriteLine("Am I a Smartphone?                {0}", telephone is Smartphone);
            Console.WriteLine("Do I Have Telephone Capabilities? {0}", telephone is ITelephone);
            Console.WriteLine("Do I Have MP3 Capabilities?       {0}", telephone is IMediaPlayer3);
            Console.WriteLine();
            var mp3 = new MediaPlayer3();
            Console.WriteLine(mp3.Name);
            mp3.PlaySong("Lalala");
            Console.WriteLine("Am I a Telephone?                 {0}", mp3 is Telephone);
            Console.WriteLine("Am I a MP3?                       {0}", mp3 is MediaPlayer3);
            Console.WriteLine("Am I a Smartphone?                {0}", mp3 is Smartphone);
            Console.WriteLine("Do I Have Telephone Capabilities? {0}", mp3 is ITelephone);
            Console.WriteLine("Do I Have MP3 Capabilities?       {0}", mp3 is IMediaPlayer3);
            Console.WriteLine();
            var smartphone = new Smartphone();
            Console.WriteLine(smartphone.Name);
            smartphone.OutboundCall("+1 234 567");
            smartphone.PlaySong("Lalala");
            Console.WriteLine("Am I a Telephone?                 {0}", smartphone is Telephone);
            Console.WriteLine("Am I a MP3?                       {0}", smartphone is MediaPlayer3);
            Console.WriteLine("Am I a Smartphone?                {0}", smartphone is Smartphone);
            Console.WriteLine("Do I Have Telephone Capabilities? {0}", smartphone is ITelephone);
            Console.WriteLine("Do I Have MP3 Capabilities?       {0}", smartphone is IMediaPlayer3);
            Console.ReadKey();
        }
        public interface IDevice
        {
            string Name { get; }
        }
        public interface ITelephone : IDevice
        {
            void OutboundCall(string number);
        }
        public interface IMediaPlayer3 : IDevice
        {
            void PlaySong(string filename);
        }
        public class Telephone : ITelephone
        {
            public string Name { get { return "Telephone"; } }
            public void OutboundCall(string number)
            {
                Console.WriteLine("Calling {0}", number);
            }
        }
        public class MediaPlayer3 : IMediaPlayer3
        {
            public string Name { get { return "MP3"; } }
            public void PlaySong(string filename)
            {
                Console.WriteLine("Playing Song {0}", filename);
            }
        }
        public class Smartphone : ITelephone, IMediaPlayer3
        {
            private readonly Telephone telephone;
            private readonly MediaPlayer3 mp3;
            public Smartphone()
            {
                telephone = new Telephone();
                mp3 = new MediaPlayer3();
            }
            public string Name { get { return "Smartphone"; } }
            public void OutboundCall(string number)
            {
                telephone.OutboundCall(number);
            }
            public void PlaySong(string filename)
            {
                mp3.PlaySong(filename);
            }
        }
    }
