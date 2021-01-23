    public class StudentVM
    {
      public StudentVM(int days)
      {
        Attendance = new int[days];
      }
      public string Name { get; set; }
      public int[] Attendance { get; set; }
    }
    public class AttendanceVM
    {
      public AttendanceVM(DateTime start, DateTime end)
      {
        int days = (end - start).Days;
        Dates = new DateTime[days];
        for (int i = 0; i < days; i++)
        {
          Dates[i] = start.AddDays[i];
        }
        Students  = new List<StudentVM>();
      }
      public DateTime[] Dates { get; set; }
      public List<StudentVM> Students { get; set; }
    }
