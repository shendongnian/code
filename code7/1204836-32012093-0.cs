    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] card = {1,2,3,4,5};
                int lmin = 4;
                int lbom = 5;
                int pass = 6;
                int mxint = 7;
                int cardinturn = 8;
                int lastsim = 9;
                int fplayer = 10;
                float ang = 30.0F;
                int playid = 100;
                string namepl = "abc";
                int numberofcard = 26;
                playerupdates pU = new playerupdates();
                pU.updateinfo(card, lmin, lbom, pass, mxint, cardinturn, lastsim, fplayer, ang, playid, namepl, numberofcard);
                byte[] data = pU.SerializeObject<playerupdates>(pU);
                string test = Encoding.UTF8.GetString(data);    //test to see if serialize is working correctly
                playerupdates newPU = pU.DeserializeObject<playerupdates>(data);
            }
        }
        [XmlRoot("playerupdates")]
        public class playerupdates
        {
            [XmlElement("cardstoad")]
            public int[] cardstoad { get; set; }
            [XmlElement("lastmin")]
            public int lastmin { get; set; }
            [XmlElement("lastbomb")]
            public int lastbomb { get; set; }
            [XmlElement("passnumber")]
            public int passnumber { get; set; }
            [XmlElement("maxvalueinturn")]
            public int maxvalueinturn { get; set; }
            [XmlElement("cardsinturn")]
            public int cardsinturn { get; set; }
            [XmlElement("lastsimiliarvalue")]
            public int lastsimiliarvalue { get; set; }
            [XmlElement("firstplayer")]
            public int firstplayer { get; set; }
            [XmlElement("angle")]
            public float angle { get; set; }
            [XmlElement("playerid")]
            public int playerid { get; set; }
            [XmlElement("playername")]
            public string playername { get; set; }
            [XmlElement("cardsin")]
            public int cardsin { get; set; }
            public void  updateinfo(int[] card, int lmin, int lbom, int pass, int mxint, int cardinturn, int lastsim, int fplayer, float ang, int playid, string namepl, int numberofcard)
            {
                //o1 not needed
                //playerupdates o1 = new playerupdates();
                cardstoad = new int[card.Length];
                for (int i = 0; i < card.Length; i++)
                {
                    cardstoad[i] = card[i];
                }
                lastmin = lmin;
                lastbomb = lbom;
                passnumber = pass;
                maxvalueinturn = mxint;
                cardsinturn = cardinturn;
                lastsimiliarvalue = lastsim;
                firstplayer = fplayer;
                angle = ang;
                playerid = playid;
                playername = namepl;
                cardsin = numberofcard;
            }
            public byte[] SerializeObject<T>(T serializableObject)
            {
                T obj = serializableObject;
                using (MemoryStream stream = new MemoryStream())
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    x.Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
            public T DeserializeObject<T>(byte[] serilizedBytes)
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream(serilizedBytes))
                {
                    return (T)x.Deserialize(stream);
                }
            }
        }
    }
    ​
