    abstract class Lesson
    {
        public event EventHandler<SpeakEventArgs> Speak;
        public string OpeningMessage { get; set; }
        public string ClosingMessage { get; set; }
        public bool completed { get; private set; } = false;
        abstract public void Do();
    
        protected virtual void RaiseSpeak(object sender, SpeakEventArgs args)
        {
            this.Speak?.Invoke(sender, args);
        }
    }
