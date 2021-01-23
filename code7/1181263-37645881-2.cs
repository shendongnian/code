	using System;
	using elios.Persist;
	using System.Collections.Generic;
	using System.IO;
						
	public class Program
	{
		public static void Main()
		{
			var students = new List<Student>();
			
			students.Add(new Student {Name = "Alfred"});
			students.Add(new Student {Name = "Ben"});
			students.Add(new Student {Name = "Camila"});
			students.Add(new Student {Name = "Denise"});
			
			var alfred = students[0];
			var ben = students[1];
			var camila = students[2];
			var denise = students[3];
			
			alfred.AddFriend(ben);
			alfred.AddFriend(camila);
			ben.AddFriend(alfred);
			ben.AddFriend(denise);
			camila.AddFriend(alfred);
			camila.AddFriend(ben);
			camila.AddFriend(denise);
			denise.AddFriend(camila);
			
			var archive = new XmlArchive(typeof(List<Student>));
			string xml;
			
			using (var s = new MemoryStream())
			{
				archive.Write(s,students,"Students");
				s.Position = 0;
				
				using (var reader = new StreamReader(s))
				{
					xml = reader.ReadToEnd();
				}	
			}
			
			Console.WriteLine(xml);
			
		}
	}
	public class Student
	{
		[Persist("Friends",IsReference = true, ChildName = "Friend")]
		private readonly List<Student> m_friends;
		public string Name { get; set; }
		public Student()
		{
			m_friends = new List<Student>();
		}
		public void AddFriend(Student friend)
		{
			m_friends.Add(friend);
		}
	}
