    public class clsGuid  ---This is class Name
    {
    	public Guid MyGuid { get; set; }
    }
    static void Main(string[] args)
            {
                clsGuid cs = new clsGuid();   
                Console.WriteLine(cs.MyGuid); --this will give empty Guid  "00000000-0000-0000-0000-000000000000"
    
                cs.MyGuid = new Guid();
                Console.WriteLine(cs.MyGuid); ----this will also give empty Guid  "00000000-0000-0000-0000-000000000000"
    
                cs.MyGuid = Guid.NewGuid();
                Console.WriteLine(cs.MyGuid); --this way, it will give new guid  "d94828f8-7fa0-4dd0-bf91-49d81d5646af"
    
                Console.ReadKey(); --this line holding the output screen in console application...
            }
