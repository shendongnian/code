    Public Shared Sub Serialize(theFilename As String, ByVal obj As LocalDBObject)
	    Dim bf As New BinaryFormatter() ' Create a binary formatter for this stream.
	    Using fileStram As File.Create(theFilename)
		    bf.Serialize(fileStram, obj);
	    End Using
    End Sub
