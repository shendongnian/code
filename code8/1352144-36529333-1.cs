    void Main()
    {
        // Test.SelectedParkDuration = 5;
       
    	var result = Test.SelectedParkDuration.Value; // Invalid operation exception with above line commented out
    	
    	result.Dump();
    }
    
    public class Test
    {
    	public static int? SelectedParkDuration { get; set;}
    }
