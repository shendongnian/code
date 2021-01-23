    public class Dog:IFixedCalculationsHelper,IDateTimerHelper
    {
        public Dog(/*other injections*/)
        {
            //Initialize
        }
        public void DoWork()
        {
            (this as IDateTimerHelper).HelpMe();
            (this as IFixedCalculationsHelper).HelpMe();
            this.HelpMeForDateTimering();
            this.HelpMeForFixedCalculations();
        }
    }
