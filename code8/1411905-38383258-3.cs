    public class PropertySyncTests
    {
        public void Should_sync_properties()
        {
            var semester = new Semester();
            var student = new Student();
            AttachProperties(x => x.Score, semester, x => x.SemesterScore, student);
            semester.Score = 7;
            student.SemesterScore.ShouldBe(7);
        }
    }
