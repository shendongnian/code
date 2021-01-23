    public class Music {
            public string Artist { get; set; }
            public string Title { get; set; }
        public Music(string artist, string title) {
            Artist = artist;
            Title = title;
        }
        public void play(string song) {
            Console.WriteLine(song);
        }
    }
    public class Rock : Music
    { 
        public Rock(string artist, string title) : base(artist, title)
        {
        }
    }
    public class Classic : Music
    {
        public Classic(string artist, string title) : base(artist, title)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Music song1 = new Rock("ac-dc", "highway to hell");
            Music song2 = new Classic("elvis presley", "love me tender");
            List<Music> list = new List<Music>();
            list.Add(song1);
            list.Add(song2);
            Console.WriteLine(list[0].Artist +", " + list[0].Title);
            Console.WriteLine(list[1].Artist + ", " + list[1].Title);
            string a = Console.ReadLine(); // just type "yeah" or whatever
            song1.play(a);
            song1.play(a);
            song1.play(a);
            song1.play(a);
            Console.ReadLine();
        }
    }
