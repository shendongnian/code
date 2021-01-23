    public class Dog
    {
        public string Name { get; set; }
    }
    public void Main()
	{
        DataTable dt = new DataTable();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.Fill(dt, Dts.Variables["User::myDogs"].Value);
        List<Dog> dogList = new List<Dog>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Dog dogs = new Dog();
            dogs.Name = dt.Rows[i]["Name"].ToString();
            dogList.Add(dogs);
        }
            Dts.TaskResult = (int)ScriptResults.Success;
	}
