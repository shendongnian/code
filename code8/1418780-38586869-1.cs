    class BubbleSort : Lesson
    {
        protected override void RaiseSpeak(object sender, SpeakEventArgs args)
        {
            // your logic here
    
            base.RaiseSpeak(sender, args);
        }
    
        public override void Do()
        {
            this.RaiseSpeak(this, new SpeakEventArgs() { Message = OpeningMessage });
        }
    }
