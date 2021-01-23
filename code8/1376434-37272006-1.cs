    public class SCustomer
    {
    	public SCustomer(int ID, string Name)
    	{
    		this.ID = ID;
    		this.Name = Name;
    	}
    	public int ID;
    	public string Name;
    }
    
    public static void Main (string[] args)
    {
    	List<SCustomer> people = new List<SCustomer>();
    	SCustomer customer1 = new SCustomer (11, "Robert");
    	SCustomer customer2 = new SCustomer (5, "Kate");
    	SCustomer customer3 = new SCustomer (23, "David");
    	people.Add(customer1);
    	people.Add(customer2);
    	people.Add(customer3);
    
    	List<int> sortingById = new List<int>();
    	List<int> sortingByName = new List<int>();
    	for(int i=0; i<people.Count; i++)
    	{
    		sortingById.Add(i);
    		sortingByName.Add(i);
    	}
    
    	sortingById.Sort( (e1, e2) => people[e1].ID.CompareTo(people[e2].ID) );
    	sortingByName.Sort( (e1, e2) => string.Compare(people[e1].Name, people[e2].Name) );
    
    	sortingById.ForEach (x => System.Console.Write (x));
    	System.Console.WriteLine ();
    	sortingByName.ForEach (x => System.Console.Write (x));
    
    }
