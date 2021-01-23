            private void button_Click(object sender, RoutedEventArgs e)
            {
                using (var context = new Model1Container())
                {
    
                    var course_List = new List<course>();
                    foreach (var course in GetAllCources)
                    {
                        course_List.Add(course);
                    }
                    listView.ItemsSource = course_List;
                }
            }
    
            private List<course> GetAllCources()
            {
                return (from c in context.cources
                 join i in context.instructors on c.instructorId equals c.Id
                 select new
                 {
                     Cources = c,
                     Instructors = i,
                 }).AsEnumerable().Select(c =>  new Cources
                 {
                     .
                     .
                     All required fields
                     .
                     .
                     .
                 } : null).AsQueryable();
            } 
