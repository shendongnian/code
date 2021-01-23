    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private class Person
            {
                public int PersonId { get; set; }
                public string Name { get; set; }
            }
    
            private class Course
            {
                public int CourseId { get; set; }
                public string CourseName { get; set; }
                public int ProfessorId { get; set; }
            }
    
            private List<Course> courses = new List<Course>();
            private List<Person> professors = new List<Person>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                courses.Add(new Course { CourseId = 1, CourseName = "Math", ProfessorId = 1 });
                courses.Add(new Course { CourseId = 2, CourseName = "English", ProfessorId = 2 });
                courses.Add(new Course { CourseId = 3, CourseName = "History", ProfessorId = 1 });
    
                professors.Add(new Person { PersonId = 1, Name = "John Doe" });
                professors.Add(new Person { PersonId = 2, Name = "Jane Doe" });
    
                cboProfessors.DisplayMember = "Name";
                cboProfessors.ValueMember = "PersonId";
                cboProfessors.DataSource = professors;
    
                grdCourses.AutoGenerateColumns = false;
                grdCourses.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseId", HeaderText = "Course ID #", DataPropertyName="CourseId" });
                grdCourses.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Course Name", DataPropertyName="CourseName" });
                grdCourses.Columns.Add(new DataGridViewComboBoxColumn { Name = "Professor", HeaderText = "Professor", DataSource = professors,
                    DisplayMember = "Name", ValueMember = "PersonId", DataPropertyName="ProfessorId" });
    
                grdCourses.DataSource = courses;
            }
    
            private void btnFilter_Click(object sender, EventArgs e)
            {
                int professorId = (int)cboProfessors.SelectedValue;
                List<Course> filteredCourses = courses.Where(x => x.ProfessorId == professorId).ToList();
                grdCourses.DataSource = filteredCourses;
            }
        }
    }
