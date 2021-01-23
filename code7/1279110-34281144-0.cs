    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                SortedList<PriorityTime, string> sList = new SortedList<PriorityTime, string>();
            }
        }
        public class PriorityTime : IComparable<PriorityTime>
        {
            public int priority { get; set; }
            public DateTime time { get; set; }
            public int CompareTo(PriorityTime other)
            {
                if (other.priority != this.priority)
                {
                    return this.priority.CompareTo(other.priority);
                }
                else
                {
                    return this.time.CompareTo(other.time);
                }
            }
        }
     
    }
