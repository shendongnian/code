    using System;
    
    namespace TimeClock
    {
        public enum BlockTypes
        {
            Working,
            Break
        }
    
        public class TimeBlock
        {
            public BlockTypes BlockType;
            public TimeLog In;
            public TimeLog Out;
    
            public TimeSpan Duration
            {
                get
                {
                    // TODO: Need error checking
                    return Out.EntryDateTime.Subtract(In.EntryDateTime);
                }
            }
    
            public override string ToString()
            {
                return $"In: {In.EntryDateTime:HH:mm} - Out: {Out.EntryDateTime:HH:mm}";
            }
    
        }
    
        // a little extension class
        public static class Extensions
        {
            public static bool IsBreak(this TimeBlock block)
            {
                // if the length of the break period is less than 19 minutes
                // we will consider it a break, the person could have clock IN late
                return block.Duration.TotalMinutes < 19 ? true : false;
    
            }
    
        }
    
    }
