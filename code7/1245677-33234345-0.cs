    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var availbleRoles = new List<Roles>();
    		availbleRoles.Add(new Roles() { Serial = 1, Name = "Test 1", IsActive = true });	
    		availbleRoles.Add(new Roles() { Serial = 2, Name = "Test 2", IsActive = true });	
    		availbleRoles.Add(new Roles() { Serial = 4, Name = "Test 4", IsActive = true });	
    		
    		
    		var updatedRoles = new List<Roles>();
    		updatedRoles.Add(new Roles() { Serial = 1, Name = "Test 1", IsActive = true });	
    		updatedRoles.Add(new Roles() { Serial = 2, Name = "Test 2", IsActive = true });	
    		updatedRoles.Add(new Roles() { Serial = 3, Name = "Test 3", IsActive = true });	
    		updatedRoles.Add(new Roles() { Serial = 4, Name = "Test 4", IsActive = true });
    		
    		
    		var roles = updatedRoles.Except(availbleRoles);
    		foreach (var role in roles)
    		{
    			Console.WriteLine("Serial : " + role.Serial + " Name : " + role.Name);
    		}
    		
    		bool isRoleUpdated = roles.Any();
    		
    		Console.WriteLine("Role Updated : " + isRoleUpdated);
    	}
    }
    
    public class Roles : System.IEquatable<Roles>
    {
        public int Serial {get; set;}
        public string Name {get;set;}
        public bool IsActive {get;set;}
    	
    	public bool Equals(Roles other)
        {
    
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the products' properties are equal.
            return Serial.Equals(other.Serial) && Name.Equals(other.Name);
        }
    	
    	// If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public override int GetHashCode()
        {
    
            //Get hash code for the Name field if it is not null.
            int hashRoleName = Name == null ? 0 : Name.GetHashCode();
    
            // Get hash code for the Serial field.
            int hashSerial = Serial.GetHashCode();
    
            //Calculate the hash code for the Role.
            return hashSerial ^ hashRoleName;
        }
    }
    
    public class Users
    {
        public string Name {get;set;}
        public Roles[] AvailableRoles { get; set; }
    }
