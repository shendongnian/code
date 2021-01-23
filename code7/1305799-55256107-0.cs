    Dim wkt As String = g.ToString '"POINT(7 7)"
    Dim udtText As New System.Data.SqlTypes.SqlChars(wkt)
    Dim sqlGeometry1 As Microsoft.SqlServer.Types.SqlGeometry = Microsoft.SqlServer.Types.SqlGeometry.STGeomFromText(udtText, srid)
    Dim ms As New MemoryStream()
    Dim bw As New BinaryWriter(ms)
    Dim WKB() As Byte = sqlGeometry1.STAsBinary().Buffer
    bw.Write(WKB)
    dbimporter.Write(WKB, NpgsqlTypes.NpgsqlDbType.Bytea)
