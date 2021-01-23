    ' *************************************************************
    ' THIS CLASS IS PARTIALLY DEFINED FOR THIS STACKOVERFLOW ANSWER
    ' *************************************************************
    
    Imports System.IO
    Imports System.Text
    Imports TagLib
    
    ''' <summary>
    ''' Represents the <c>Lyrics3</c> tag for a MP3 file.
    ''' </summary>
    Public Class Lyrics3Tag
    
        Protected ReadOnly mp3File As Mpeg.AudioFile
    
        ''' <summary>
        ''' The maximum length for the <c>Lyrics3</c> block to prevent issues like removing a false-positive block of data.
        ''' <para></para>
        ''' Note that this is a personal attempt to prevent catastrophes, not based on any official info.
        ''' </summary>
        Private ReadOnly maxLength As Integer = 512 ' bytes
    
        Private Sub New()
        End Sub
    
        Public Sub New(ByVal mp3File As Mpeg.AudioFile)
            Me.mp3File = mp3File
        End Sub
    
        ''' <summary>
        ''' Entirely removes the <c>Lyrics3</c> tag.
        ''' </summary>
        <DebuggerStepThrough>
        Public Overridable Sub Remove()
    
            Dim initVector As New ByteVector(Encoding.UTF8.GetBytes("LYRICSBEGIN"))
            Dim initOffset As Long = Me.mp3File.Find(initVector, startPosition:=0)
    
            If (initOffset <> -1) Then
    
                ' The Lyrics3 block can end with one of these two markups, so we need to evaluate both.
                For Each str As String In {"LYRICS200", "LYRICSEND"}
    
                    Dim endVector As New ByteVector(Encoding.UTF8.GetBytes(str))
                    Dim endOffset As Long = Me.mp3File.Find(endVector, startPosition:=initOffset)
    
                    If (endOffset <> -1) Then
    
                        Dim length As Integer = CInt(endOffset - initOffset) + (str.Length)
                        If (length < Me.maxLength) Then
                            Try
                                Me.mp3File.Seek(initOffset, SeekOrigin.Begin)
                                ' Dim raw As String = Me.mp3File.ReadBlock(length).ToString()
                                Me.mp3File.RemoveBlock(initOffset, length)
                                Exit Sub
    
                            Catch ex As Exception
                                Throw
    
                            Finally
                                Me.mp3File.Seek(0, SeekOrigin.Begin)
    
                            End Try
    
                        Else ' Length exceeds the max length.
                             ' We can handle it or continue...
                            Continue For
    
                        End If
    
                    End If
    
                Next str
    
            End If
    
        End Sub
    
    End Class
