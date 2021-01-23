    public string FormatDetailsForDisplay()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Course ID: ").Append(this.CourseId);
        sb.Append(" - Name: ").Append(this.Name).Append(" - Students: {");
        sb.Append(this.Students[0].FormatDetailsForDisplay());
        for (int i = 1; i < this.Students.Count; i++)
        {
            sb.Append(", ").Append(this.Students[i].FormatDetailsForDisplay());
        }
        sb.Append("} <br/>");
        return sb.ToString();
    }
    // Update FormatDetailsForDisplay() for the Students class depending on how you built it
    public class Student
    {
        public string Name;
        public int Age;
        public string FormatDetailsForDisplay()
        {
            return "Name: " + this.Name + " - Age: " + this.Age.ToString();
        }
    }
