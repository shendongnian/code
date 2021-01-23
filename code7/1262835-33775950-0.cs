    class Employee
	{
		public double Salary { get; set; }
		public double Bonus { get; set; }
		public string Name { get; set; }
		public Employee(String name, double salary, double bonus)
		{
			Salary = salary;
			Bonus = bonus;
			Name = name;
		}
		public void CalculateTotalPay()
		{
			double totalPay = Salary + Bonus;
			Console.WriteLine("Total  Pay for {0} = {1}", Name, totalPay);
		}
	}
