    public class employee
    {
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public employee(int id, string _name)
    {
        ID = id;
        Name = _name;
        Date = DateTime.Now;
    }
    public employee()
    {
    }
    }
