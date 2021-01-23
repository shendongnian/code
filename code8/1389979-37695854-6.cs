        public List<DateRange> Intersect2(DateRange d)
        {
            var s = (d.Start > this.Start) ? d.Start : this.Start; // Later Start
            var e = (d.End < this.End) ? d.End : this.End; // Earlier ending
            if (s < e)
                return new List<DateRange>()
                {
                    new DateRange() { Start = new DateTime(Math.Min(Start.Ticks, d.Start.Ticks)), End = s },
                    new DateRange() { Start = e, End = new DateTime(Math.Max(End.Ticks, d.End.Ticks)) }
                };
            else
                return null;
        }
