    using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	namespace PivotDataTable
	{
		class Program
		{
			public static object GetPropValue(object src, string propName)
			{
				return src.GetType().GetProperty(propName).GetValue(src, null);
			}
			
			static void Main()
			{
				// retrieve object list
				var classGrades = new List<ClassGrades>() {
					new ClassGrades() {Id=1, ClassId=1, Student="Mark", Math=50.6, Science=21.8, History=70.7, English=80.1},
					new ClassGrades() {Id=2, ClassId=1, Student="Jacob", Math=70.8, Science=19.4, History=78.7, English=11.1},
					new ClassGrades() {Id=3, ClassId=1, Student="Lauren", Math=21.9, Science=61.1, History=99.5, English=12.1},
					new ClassGrades() {Id=4, ClassId=1, Student="Sarah", Math=81.7, Science=65.2, History=73.7, English=65.1}
				};
				
				// create datatable
				DataTable dt = new DataTable();
				
				// get list of students
				var students = from s in classGrades
					select s.Student;
				
				// get list of subjects
				var subjects = new List<string>() { "Math", "Science", "History", "English" };
				
				// create columns
				dt.Columns.Add("subject", typeof(string));
				foreach (var student in students)
				{
					dt.Columns.Add(student, typeof(double));
				}
				
				// create rows
				foreach (var subject in subjects)
				{
					var row = dt.NewRow();
					row[0] = subject;
					
					foreach (var classGrade in classGrades)
					{
						row[classGrade.Student] = Convert.ToDouble(GetPropValue(classGrade, subject));
					}
					
					// add row to data table
					dt.Rows.Add(row);
				}
				
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
		
		class ClassGrades
		{
			public int Id { get; set; }
			public int ClassId { get; set; }
			public string Student { get; set; }
			public double Math { get; set; }
			public double Science { get; set; }
			public double History { get; set; }
			public double English { get; set; }
		}
	}
