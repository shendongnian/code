    Imports System
    				
    Public Module Module1
    	Public Sub Main()
    		dim x as testparent = new testchild1
    		dim y as testparent = new testchild2
    		
    		if x.GetType() is y.Gettype() then
    			console.writeline("they are the same type")
    		else
    			console.writeline("they are different types")
    		end if
    			
    			
    	End Sub
    	
    	
    End Module
    
    public class testparent
    	end class
    	
    	
    	public class testchild1: inherits testparent
    		
    	end class
    	
    	
    public class testchild2: inherits testchild1
    		
    	end class
