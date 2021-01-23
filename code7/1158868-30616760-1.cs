    public class Pet
    {
    	public string Name { get; set; }
    	public float Weight { get; set; }
    	public bool Alive { get; set; }
    
        //defining a custom constructor
    	public Pet(string name, float weight, bool alive)
    	{
    		this.Name = name;      //assign input parameter value to the Property
    		this.Weight = weight;
    		this.Alive = alive;
    	}
    }
