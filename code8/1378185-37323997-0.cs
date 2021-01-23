	var classWithTeacherAndStudent =
	from Class in classes
	join Teacher in teacher
		on Class.Number equals Teacher.Class
	let teacherClass = new { Class, Teacher }
	join student in students
		on teacherClass.Class.Number equals student.Class
		into entireClass
	select new
	{
		teacherClass.Teacher, teacherClass.Class, entireClass
	};
	foreach (var entry in classWithTeacherAndStudent)
	{
		Console.WriteLine("teacher: {0}, class: {1}", entry.Teacher.Name, entry.Class.Number);
		foreach (var student in entry.entireClass)
		{
			Console.WriteLine(student.Name);
		}
	}
