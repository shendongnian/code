    static void Main(string[] args)
	{
		List<Employee> empList = new List<Employee>();
        empList.Add(new Employee() { ID = 1, FName = "John", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
        empList.Add(new Employee() { ID = 2, FName = "Mary", LName = "Jacobs", DOB = DateTime.Parse("01/12/1961"), Sex = 'F' });
        empList.Add(new Employee() { ID = 3, FName = "Amber", LName = "Agar", DOB = DateTime.Parse("05/12/1971"), Sex = 'M' });
        empList.Add(new Employee() { ID = 4, FName = "Kathy", LName = "Berry", DOB = DateTime.Parse("11/06/1976"), Sex = 'F' });
        empList.Add(new Employee() { ID = 5, FName = "Lena", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
		XmlSerializer serializer = new XmlSerializer(empList.GetType());
		serializer.Serialize(Console.Out, empList);
		Console.ReadKey();
	}
