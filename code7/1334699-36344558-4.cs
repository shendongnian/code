    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the <c>MP3GAIN_MINMAX</c> metatada field of the audio file.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Overridable Property MP3GainMinMax As String
        <DebuggerStepThrough>
        Get
            Return Me.GetFieldMP3GainMinMax
        End Get
        <DebuggerStepThrough>
        Set(ByVal value As String)
            Me.SetFieldMP3GainMinMax(value)
        End Set
    End Property
