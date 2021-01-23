    public class DateRange : IEquatable<DateRange>
            {
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
    
                public DateRange Intersect(DateRange d)
                {
                    var s = (d.Start > this.Start) ? d.Start : this.Start; // Later Start
                    var e = (d.End < this.End) ? d.End : this.End; // Earlier ending
    
                    if (s < e)
                        return new DateRange() { Start = s, End = e };
                    else
                        return null;
                }
    
                public bool Contains(DateTime d)
                {
                    return d >= Start && d <= End;
                }
    
                public bool Equals(DateRange obj)
                {
                    return Start.Equals(obj.Start) && End.Equals(obj.End);
                }
            }
