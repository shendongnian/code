	Imports System.Runtime.CompilerServices
	
	Module ExtensionMethods
	
		<Extension()> 
		Public Shared Function GetColumnByHeader(grid As GridView, name As String) As DataControlField
			Dim index As Integer = -1
			For i As Integer = 0 To grid.Columns.Count - 1
				If grid.Columns(i).HeaderText.ToLower().Trim() = name.ToLower().Trim() Then
					index = i
					Exit For
				End If
			Next
			Return grid.Columns(index)
		End Function
	
	End Module
