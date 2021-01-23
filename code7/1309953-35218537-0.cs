    Public Interface IDoSomething
    	Sub DoNothing()
    
    End Interface
    Public Class Class1
    	Private _zyx As IDoSomething
    	Public Property Xyz As IDoSomething
    		Get
    			Return _zyx
    		End Get
    		Set(value As IDoSomething)
    			If value Is _zyx Then Return
    
    			If _zyx IsNot Nothing Then
    				_zyx.DoNothing()
    			End If
    			_zyx = value
    
    			If _zyx IsNot Nothing Then
    				_zyx.DoNothing()
    			End If
    		End Set
    	End Property
    
    End Class
