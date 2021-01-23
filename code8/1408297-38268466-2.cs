	Imports System.Runtime.CompilerServices
	
	Module ExtensionMethods
	
        <Extension()>
        Public Function GetColumnIndexByHeader(grid As GridView, name As String) As Integer
            For i As Integer = 0 To grid.Columns.Count - 1
                If grid.Columns(i).HeaderText.ToLower().Trim() = name.ToLower().Trim() Then
                    Return i
                End If
            Next
            Return -1
        End Function
	
	End Module
