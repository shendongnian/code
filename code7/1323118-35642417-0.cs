    Option Infer On
    
    Module Test
    	<System.Runtime.CompilerServices.Extension>
    	Public Function FindAllChildrenByType(Of T)(control As Control) As IEnumerable(Of T)
    		Dim controls = control.Controls.Cast(Of Control)()
    		Dim enumerable = If(TryCast(controls, IList(Of Control)), controls.ToList())
    		Return enumerable.OfType(Of T).Concat(enumerable.SelectMany(AddressOf FindAllChildrenByType(Of T)))
    	End Function
    
    	<System.Runtime.CompilerServices.Extension>
    	Public Function FindChildByType(Of T)(control As Control, ctrlName As String) As T
    		For Each ctrlx In From ctrl In FindAllChildrenByType(Of T)(control) Let testControl = TryCast(ctrl, Control) Where testControl IsNot Nothing AndAlso testControl.Name.ToUpperInvariant() = ctrlName.ToUpperInvariant() Select ctrl
    			Return ctrlx
    		Next
    		Return Nothing
    	End Function
    End Module
