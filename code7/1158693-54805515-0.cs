    Private Sub closeformdisposingpictureboxes(f As Form)
        For Each c As Control In f.Controls
            If TypeOf c Is PictureBox Then
                Dim pbox As PictureBox = CType(c, PictureBox)
                pbox.Image.Dispose()
            End If
        Next
        f.Close()
        f.Dispose()
    End Sub
