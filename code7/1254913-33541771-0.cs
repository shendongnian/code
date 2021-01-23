    Sub Main
    	Dim a as A
    	a = new A()
    	a.Prop2.Name = "A"
    End Sub
    
    Structure Test
    	public Name as String
    End Structure
    
    Class A
    	public property Prop2 As Test = new Test()
    End Class
