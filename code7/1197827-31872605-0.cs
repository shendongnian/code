    public class Program
    {
       
        public class Orchestra
        {
            public Instrument[] Instruments {get; set;}
        }
        [XmlInclude(typeof(Brass))]
        [XmlInclude(typeof(Guitar))]
        public class Instrument
        {
            public string Name { get; set; }
            [XmlIgnore]
            public string DoNotSerialize { get; set; }
        }
        public class Brass : Instrument
        {
            public bool IsValved { get; set; }
            public override string ToString()
            {
                return string.Format("This is a{0} Brass.",IsValved?" valved":"n unvalved");
            }
        }
        public class Guitar: Instrument
        {
            public int Strings { get; set; }
            public override string ToString()
            {
                return String.Format("This is a {0} string Guitar.", Strings);
            }
        }
        static XmlSerializer s;
        static void Main(string[] args)
        {
            s = new XmlSerializer(typeof(Orchestra));
            serialize("%temp%test.xml");
            deserialize("%temp%test.xml");
            Console.ReadLine();
        }
        static void serialize(string filename)
        {
            Orchestra o = new Orchestra();
            o.Instruments = new Instrument[]
            {
                new Brass
                {
                    IsValved=true
                },
                new Brass {IsValved=false },
                new Guitar {Strings=12 }
            };
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                s.Serialize(fs, o);
            }
        }
    
        static void deserialize(string filename)
        {
            Orchestra band;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                band = (Orchestra)s.Deserialize(fs);
            }
            foreach (Instrument i in band.Instruments)
            {
                Console.WriteLine("{0}: {1}", i.GetType(), i.ToString());
            }
        }
    }
