    void Main()
    {
    	// Variant 1 - Chaining
    	var editorChain = new UpperCaseFileEditor(new LowerCaseFileEditor());
    	var data1 = new char[] { 'a', 'B', 'c' };
    	editorChain.Edit(data1);
    	data1.Dump(); // produces ['a','b','c']
    	
    	// Variant 2 - Iteration
    	var editors = new List<IFileEditor> { new LowerCaseFileEditor(), new UpperCaseFileEditor() };
    	var data2 = new char[] { 'a', 'B', 'c' };
    	
    	foreach (var e in editors) {
    		e.Edit(data2);
    	}
    	
    	data2.Dump(); // produces ['A','B','C']
    }
    
    // Define other methods and classes here
    public interface IFileEditor {
    	IFileEditor Next { get; set; }
    	void Edit(char[] data);
    }
    
    public class UpperCaseFileEditor : IFileEditor {
    	public IFileEditor Next { get; set; }
    
    	public UpperCaseFileEditor() : this(null) {}
    	public UpperCaseFileEditor(IFileEditor next) {
    		Next = next;
    	}
    
    	public void Edit(char[] data) {
    		for (int i = 0; i < data.Length; ++i) {
    			data[i] = Char.ToUpper(data[i]);
    		}
    		
    		if (Next != null)
    			Next.Edit(data);
    	}
    }
    
    public class LowerCaseFileEditor : IFileEditor {
    	public IFileEditor Next { get; set; }
    
    	public LowerCaseFileEditor() : this(null) {}
    	public LowerCaseFileEditor(IFileEditor next) {
    		Next = next;
    	}
    
    	public void Edit(char[] data) {
    		for (int i = 0; i < data.Length; ++i) {
    			data[i] = Char.ToLower(data[i]);
    		}
    		
    		if (Next != null)
    			Next.Edit(data);
    	}
    }
