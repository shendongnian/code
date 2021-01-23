    interface ITelephone { }
    class Telephone
    {
        public string name { get; set; }
        public Telephone()
        {
            name = "name telephone";
        }
    }
    interface IMP3 { }
    class MP3 : IMP3
    {
        public string name { get; set; }
        public MP3()
        {
            name = "name mp3";
        }
    }
    class TelephoneMP3 : ITelephone, IMP3
    {
        public Telephone tel;
        public MP3 mp3;
        public TelephoneMP3()
        {
            tel = new Telephone();
            mp3 = new MP3();
        }
    }
