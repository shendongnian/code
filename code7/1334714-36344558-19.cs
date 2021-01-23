    Property MP3GainMinMax As String
        Get
            Return Me.GetField("MP3GAIN_MINMAX")
        End Get
        Set(ByVal value As String)
            Me.SetField("MP3GAIN_MINMAX", value)
        End Set
    End Property
    Property MP3GainUndo As String
        Get
            Return Me.GetField("MP3GAIN_UNDO")
        End Get
        Set(ByVal value As String)
            Me.SetField("MP3GAIN_UNDO", value)
        End Set
    End Property
    Property ReplayGainTrackGain As String
        Get
            Return Me.GetField("REPLAYGAIN_TRACK_GAIN")
        End Get
        Set(ByVal value As String)
            Me.SetField("REPLAYGAIN_TRACK_GAIN", value)
        End Set
    End Property
    Property ReplayGainTrackPeak As String
        Get
            Return Me.GetField("REPLAYGAIN_TRACK_PEAK")
        End Get
        Set(ByVal value As String)
            Me.SetField("REPLAYGAIN_TRACK_PEAK", value)
        End Set
    End Property
