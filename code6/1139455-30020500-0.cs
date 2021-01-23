    public class InterestingEventArgs:EventArgs
    {
       public string AnInterestingFact {get;private set;}
       public InterestingEventArgs(string fact)
       {
         AnInterestingFact =fact;
       }
    }
