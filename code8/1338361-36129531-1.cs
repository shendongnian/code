        public list<Segment> FillSegment(int siteid)
        {
            using (DBConnection db = new DBConnection())
            {
                var segment = db.Segment.Where(c => c.SiteID == siteid).Select(x => new
            {
                SegmentID = x.SegmentID,
                SegmentName = x.SegmentName
            }).toList();
            return segment;
            }
        }
