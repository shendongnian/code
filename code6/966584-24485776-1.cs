    public interface ITelephone
    {
        string Name{get;}
        void MakeCall();
    }
    public interface IMp3
    {
        string Name { get; }
        void Play(string filename);
    }
    public abstract class BaseTelephone : ITelephone
    {
        public virtual string Name { get { return "Telephone"; } }
        void MakeCall()
        {
            // code to make a call.
        }
    }
    public class MyMp3Player : IMp3
    {
        public string Name { get { return "Mp3 Player"; } }
        public void Play(string filename)
        {
            // code to play an mp3 file.
        }
    }
    public class SmartPhone : BaseTelephone, IMp3
    {
        public override string Name { get { return "SmartPhone"; } }
        private IMp3 Player { get { return _Player; } set { _Player = value; } }
        private IMp3 _Player = new MyMp3Player();
        public void Play(string filename) { Player.Play(filename); }
    }
