    internal abstract class Lesson
    {
        public event EventHandler<SpeakEventArgs> Speak;
    
        public string OpeningMessage { get; set; }
        public string ClosingMessage { get; set; }
        public bool completed { get; private set; } = false;
    
        abstract public void Do();
    
        protected void DoSpeak(SpeakEventArgs e)
        {
            if (this.Speak != null)
            {
                this.Speak(this, e);
            }
        }
    }
    
    internal class BubbleSort : Lesson
    {
        public override void Do()
        {
            base.DoSpeak(new SpeakEventArgs { Message = OpeningMessage });
        }
    }
