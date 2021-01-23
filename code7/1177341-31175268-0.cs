    public class Organization
    {
        public List<IJob> Jobs { get; set; }
    	private IJob bigBoss;
    	public IJob BigBoss { get {return Jobs[0];} set { Jobs[0] = value; } }
    
        public Organization()
        {    	
            bigBoss = new Doctor();	    
            Jobs = new List<IJob>
            {
                bigBoss,
                new Doctor(),
                new Doctor()
            };   		
        }
    }
