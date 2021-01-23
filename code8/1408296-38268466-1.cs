	Imports System.Runtime.CompilerServices
	
	Module ExtensionMethods
	
		<Extension()> _
		Public Function GetColumnIndexByHeader(grid As GridView, name As String) As Integer
			Dim index As Integer = -1
			For i As Integer = 0 To grid.Columns.Count - 1
				If grid.Columns(i).HeaderText.ToLower().Trim() = name.ToLower().Trim() Then
					index = i
					Exit For
				End If
			Next
			Return index
		End Function
	
	End Module
