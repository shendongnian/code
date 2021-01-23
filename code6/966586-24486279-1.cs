    class User
    {
        void UseSmartPhone(SmartPhone smartPhone)
        {
            // Cannot access private property 'Name' here
            Console.WriteLine(smartPhone.Name);
            // Cannot access explicit implementation of 'IMp3Player.Play'
            smartPhone.Play();
            // You can send the phone to the method that accepts an IMp3Player though
            PlaySong(smartPhone);
            // This works fine. You are sure to get the Phone name here.
            Console.WriteLine(((IPhone)smartPhone).Name);
            // This works fine, since the Call is public in SmartPhone.
            smartPhone.Call();
        }
        void CallSomeone(IPhone phone)
        {
            phone.Call();
        }
        void PlaySong(IMp3Player player)
        {
            player.Play();
        }
    }
    class SmartPhone : IPhone, IMp3Player
    {
        private Phone mPhone;
        private Mp3Player mMp3Player;
        public SmartPhone()
        {
            mPhone = new Phone();
            mMp3Player = new Mp3Player();
        }
        public void Call()
        {
            mPhone.Call();
        }
        string IPhone.Name
        {
            get { return mPhone.Name; }
        }
        string IMp3Player.Name
        {
            get { return mMp3Player.Name; }
        }
        void IMp3Player.Play()
        {
            mMp3Player.Play();
        }
    }
    class Mp3Player
    {
        public string Name { get; set; }
        public void Play()
        {
        }
    }
    class Phone
    {
        public string Name { get; set; }
        public void Call()
        {
        }
    }
    interface IPhone
    {
        string Name { get; }
        void Call();
    }
    interface IMp3Player
    {
        string Name { get; }
        void Play();
    }
