    class CourseDetails
    {
        public CourseDetails(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    class CourseDetailsEqualityComparer : EqualityComparer<CourseDetails>
    {
        public override bool Equals(CourseDetails x, CourseDetails y)
        {
            return x.Id == y.Id;
        }
        public override int GetHashCode(CourseDetails obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    [TestMethod]
    public void FindDistinct()
    {
        var courses = new List<CourseDetails> { 
            new CourseDetails(4),
            new CourseDetails(2),
            new CourseDetails(3),
            new CourseDetails(2),
            new CourseDetails(3),
            new CourseDetails(1),
            new CourseDetails(1),
        };
        var expected = new List<CourseDetails> {
            new CourseDetails(4),
            new CourseDetails(2),
            new CourseDetails(3),
            new CourseDetails(1),
        };
        var distinct = courses.Distinct(new CourseDetailsEqualityComparer()).ToList();
        CollectionAssert.AreEqual(expected, distinct, new CourseDetailsComparer());
    }
    class CourseDetailsComparer : Comparer<CourseDetails>
    {
        public override int Compare(CourseDetails x, CourseDetails y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
