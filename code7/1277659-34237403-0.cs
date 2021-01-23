    public static void Main()
    {
    
    string[] a= new string[5]{"Slot1","Slot2","Slot3","Slot4","Slot5"};
    string[] b= new string[5]{"abc","def","ghi","jkl","mno"};
    
    var whatever = new Whatever();
    for(int i = 0; i < a.Length;  i++)
        {
            var prop = a[i];
    		var value = b[i];
    		Console.WriteLine(prop);
            var propertyInfo = whatever.GetType().GetProperty(prop);
    		Console.WriteLine(propertyInfo);
            if(propertyInfo != null) propertyInfo.SetValue(whatever, value,null);
    		
        }
    	
    	Console.WriteLine(whatever.ToString());
    
    
    }
    
    public class Whatever {
    public string Slot1{get;set;}
    public string Slot2{get;set;}
    public string Slot3{get;set;}
    public string Slot4{get;set;}
    public string Slot5{get;set;}
    
    public override string ToString(){
    
    return "Slot 1 : " + Slot1  + "\n" +
    "Slot 2 : " + Slot2  + "\n" +
    "Slot 3 : " + Slot3  + "\n" +
    "Slot 4 : " + Slot4  + "\n" +
    "Slot 5 : " + Slot5 ;
    }
    }
