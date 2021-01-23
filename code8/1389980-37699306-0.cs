    public class DateSpan
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Contains(DateSpan ds)
        {
            return ds.Start >= Start && ds.End <= End ;
        }
        public bool IsHitTo( DateTime i)
        {
            return i>= Start && i<= End ;
        }
        public List<DateSpan> GetFreeTime( DateSpan i)
        {
            List<DateSpan> ld = new  List<DateSpan> ();
            if( IsHitTo( i.Start))
            {
                ld.Add(new DateSpan(){ Start = this.Start, End = I.End});
                if( IsHitTo( i.End))
                {
                     ld.Add(new DateSpan(){ Start = i.Start, End = i.Start});
                }
            }
            else
            {
                 if( IsHitTo( i.Start))
                {
                     ld.Add(new DateSpan(){ Start = i.End, End = this.End});
                }
                else
                {
                     if(i.Contains(this))
                    {
                         return new  List<DateSpan> ();
                    }
                    else
                    {
                         ld.Add(this);
                    }
                }
            }
            return ld;
       }
    }
