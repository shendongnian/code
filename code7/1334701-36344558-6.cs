    Protected Overridable Sub SetFieldMP3GainMinMax(ByVal value As String)
        Dim apeTag As TagLib.Ape.Tag = 
            DirectCast(Me.mp3File.GetTag(TagTypes.Ape, create:=True), TagLib.Ape.Tag)
        apeTag.SetValue("MP3GAIN_MINMAX", value)
    End Sub
