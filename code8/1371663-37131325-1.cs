    Random rng = new Random();
    private IList<Course> SmartShuffle(IList<Course> oldList)
    {
        IList<Course> newList = new List<Course>();
        while (true)
        {
            var randomOrder = oldList.OrderBy(x => rng.Next()).ToList();
    
            int counter = 0;
            foreach(var course in oldList)
            {
                newList.Add(new Course() { Name = randomOrder[counter].Name, Hour = course.Hour });
    
                counter++;
            }
    
            int differenceCount = newList.Count(n => oldList.Any(o => o.Name == n.Name && o.Hour != n.Hour));
    
            // leave only one of the below if statements
    
            // case at least 1 element should be different
            if (differenceCount > 0)
                break;
    
            // case all elements must be different
            if (differenceCount == oldList.Count)
                break;
        }
    
        return newList;
    }
    
    public class Course
    {
        public string Name { set; get; }
        public int Hour { set; get; }
    }
