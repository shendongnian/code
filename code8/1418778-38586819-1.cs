    abstract class Lesson
    {
        public event EventHandler<SpeakEventArgs> Speak;
    
        public virtual void Do()
        {
            this.Speak?.Invoke(sender, args);
        }
    }
    
    class BubbleSort : Lesson
    {
        public override void Do()
        {
            base.Do();
            //do something BubbleSort related
        }
    }
