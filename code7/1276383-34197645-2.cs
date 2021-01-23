    public class BreakTimeResult
    {
        public BreakTimeResult(int breakFromSec, int breakUntilSec)
        {
            BreakFromSec = breakFromSec;
            BreakUntilSec = breakUntilSec;
        }
    
        public int BreakFromSec { get; }
        public int BreakUntilSec { get; }
    }
    public static class BreakTimeCalculator
    {
        public static BreakTimeResult CalculateBreakFromAndBreakeUntil(int customBreakSec,
                                                                       int fromSec,
                                                                       int untilSec,
                                                                       int equlizer)
        {
            var taskLength = untilSec - fromSec;
            var middleOfTask = fromSec + (taskLength / 2);
            var secondsToMoveLeft = middleOfTask % 300;
            var amountEqualizers = customBreakSec / equlizer;
            var fiftyFifty = amountEqualizers % 2 == 0;
            var leftSideEqualizers = fiftyFifty 
                ? amountEqualizers / 2 
                : (amountEqualizers / 2) + 1;
            var breakFromSec = middleOfTask - secondsToMoveLeft - (leftSideEqualizers * equlizer);
            var breakUntilSec = breakFromSec + customBreakSec;
            return new BreakTimeResult(breakFromSec, breakUntilSec);
        }
    }
