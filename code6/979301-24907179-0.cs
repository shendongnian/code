    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public List<Event> Events { get; set; }
        public Course(int _courseId, string _courseName, string _courseDesc, List<Event> _events)
        {
            CourseId = _courseId;
            CourseName = _courseName;
            CourseDesc = _courseDesc;
            Events = _events;
        }
    }
    public class Event
    {
        public string EventName { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public Event(string _eventName, string _eventStart, string _eventEnd)
        {
            EventName = _eventName;
            EventStart = _eventStart;
            EventEnd = _eventEnd;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xdoc = XDocument.Load(@"F:\Test\XMLChildNodesSelection\XMLFile1.xml");
            var course = xdoc.Descendants("Course")
               .Select(x => new Course((int)x.Element("CourseId"),
                                     (string)x.Element("CourseName"),
                                     (string)x.Element("CourseDesc"),
                                     (List<Event>)x.Descendants("Event")
                                         .Select(y => new Event(
                                             (string)y.Element("EventName"),
                                             (string)y.Element("EventStart"),
                                             (string)y.Element("EventEnd")
                                             )).ToList()
                                       )
                       );
            var table = from c in course
                        from e in c.Events
                        select new
                        {
                            CourseId = c.CourseId,
                            CourseName = c.CourseName,
                            CourseDesc = c.CourseDesc,
                            EventName = e.EventName,
                            EventStart = e.EventStart,
                            EventEnd = e.EventEnd
                        };
        }
    }
}
