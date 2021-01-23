    Public Module JsonExtensions
	    <System.Runtime.CompilerServices.Extension> 
	    Public Sub Populate(Of T As Class)(value As JToken, target As T)
		    Using sr = value.CreateReader()
				' Uses the system default JsonSerializerSettings
			    JsonSerializer.CreateDefault().Populate(sr, target)
		    End Using
	    End Sub
    End Module 
