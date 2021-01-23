			using System;
			using System.Collections;
			class Program
			{
				public static void Main(string[] args)
				{
					Student student1 = new Student();
					student1.FirstName = "a";
					student1.LastName = "w";
					Student student2 = new Student();
					student2.FirstName = "e";
					student2.LastName = "s";
					Student student3 = new Student();
					student3.FirstName = "i";
					student3.LastName = "o";
					Course c = new Course();
					ArrayList students = new ArrayList();
					c.students.Add(student1);
					c.students.Add(student2);
					c.students.Add(student3);
					foreach (Student o in c.students)
					{
						Student s = (Student)o;
						Console.WriteLine(s.FirstName);
					}
					Console.ReadLine();
				}
			}
			internal class Course
			{
				public ArrayList students = new ArrayList();
			}
			internal class Student
			{
				private string firstName;
				private string lastName;
				public Student()
				{
				}
				public Student(string fname)
				{
					this.FirstName = fname;
				}
				public string FirstName
				{
					get
					{
						return firstName;
					}
					set
					{
						firstName = value;
					}
				}
				public string LastName
				{
					get
					{
						return lastName;
					}
					set
					{
						lastName = value;
					}
				}
			}
