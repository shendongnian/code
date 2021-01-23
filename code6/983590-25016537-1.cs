    // This class inherits from CheckedListBoxand implements a different  
    // sorting method. 
    public class SortSpecialCheckedListBox:
    	CheckedListBox
    
    {
    	public SortSpecialCheckedListBox() : base()
    	{        
    	}
    
    	// Overrides the parent class Sort to perform the specialised sorting
        // behaviour you are interested in
    	protected override void Sort()
    	{
    		// Do your specialised sort here.
    	}
    }
