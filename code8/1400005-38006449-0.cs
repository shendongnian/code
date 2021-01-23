    static void Main(string[] args)
    {
        Do("qwerty");
    }
    public static void Do(string text)
    {
        int i = 1;
        Text output = new Text();
        output.Add(new Dot(i));
        i = i * 2;
        foreach(char c in text)
        {
            output.Add(new textChar(c));
            output.Add(new Dot(i));
            i = i * 2;
        }
        int possibilites = output.Possibilites;
        for (i = 0; i < possibilites; i++)
        {
            Console.WriteLine(output.ToString(i));
        }
    }
    public class Text
    {
        public List<character> characters = new List<character>();
        public void Add(character c)
        {
            characters.Add(c);
        }
        public int Possibilites
        {
            get
            {
                return Convert.ToInt32(Math.Pow(2, characters.Count(C => C is Dot)));
            }
        }
        public string ToString(int i)
        {
            string output = "";
            foreach (character c in characters)
            {
                if (c is textChar)
                {
                    output += c.c;
                }
                else if (c is Dot)
                {
                    if ((i & ((Dot)c).index) != 0)
                        output += c.c;
                }
            }
            return output;
        }
    }
    public class character
    {
        public char c { set; get; }
    }
    public class textChar : character
    {
        public textChar(char c)
        {
            this.c = c;
        }
    }
    public class Dot : character
    {
        public int index;
        public Dot(int i)
        {
            index = i;
            c = '.';
        }
    }
