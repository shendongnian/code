    Protected Overridable Function GetFieldMP3GainMinMax() As String
        Dim apeTag As TagLib.Ape.Tag =
            DirectCast(Me.mp3File.GetTag(TagTypes.Ape, create:=False), TagLib.Ape.Tag)
        If (apeTag IsNot Nothing) Then
            Dim item As TagLib.Ape.Item = apeTag.GetItem("MP3GAIN_MINMAX")
            If (item IsNot Nothing) Then
                Return item.ToString()
            End If
        End If
        Return String.Empty
    End Function
