    Public Class TextBoxIcon
        Public Shared Function AddIcon(textbox As TextBox, icon As Image) As TextBoxIcon
            If (icon IsNot Nothing) Then
                Return New TextBoxIcon(textbox, icon)
            Else
                Return Nothing
            End If
        End Function
    
        Private _TextBox As TextBox
        Private _PictureBox As PictureBox
    
        Private Sub New(textbox As TextBox, icon As Image)
            _TextBox = textbox
            _PictureBox = New PictureBox()
            _PictureBox.BackColor = textbox.BackColor
            _PictureBox.Image = ScaleImage(icon)
            _TextBox.Parent.Controls.Add(_PictureBox)
            _PictureBox.Location = New Point(textbox.Left + 5, textbox.Top + 2)
            _PictureBox.Size = New Size(textbox.Width - 10, textbox.Height - 4)
            _PictureBox.Anchor = textbox.Anchor
            _PictureBox.Visible = _TextBox.Visible
            _PictureBox.BringToFront()
            AddHandler textbox.Resize, AddressOf TextBox_Resize
            AddHandler textbox.TextChanged, AddressOf TextBox_TextChanged
            AddHandler textbox.Leave, AddressOf TextBox_Leave
            AddHandler _PictureBox.Click, AddressOf PictureBox_Click
            AddHandler textbox.VisibleChanged, AddressOf TextBox_VisibleChanged
        End Sub
    
        Public Shared Function ScaleImage(img As Image) As Image
            If (img.Height = 16) Then
                Return img
            Else
                Return New Bitmap(img, New Size(CInt((img.Height / 16.0) * img.Width), 16))
            End If
        End Function
    
        Private Sub TextBox_Resize(sender As Object, e As System.EventArgs)
            _PictureBox.Size = New Size(_TextBox.Width - 10, _TextBox.Height - 4)
        End Sub
    
        Private Sub TextBox_VisibleChanged(sender As Object, e As System.EventArgs)
            _PictureBox.Visible = _TextBox.Visible
        End Sub
    
        Private Sub ShowPictureBox()
            _PictureBox.Visible = String.IsNullOrEmpty(_TextBox.Text)
        End Sub
    
        Private Sub TextBox_TextChanged(sender As Object, e As System.EventArgs)
            ShowPictureBox()
        End Sub
    
        Private Sub TextBox_Leave(sender As Object, e As System.EventArgs)
            ShowPictureBox()
        End Sub
    
        Public Sub PictureBox_Click(sender As Object, e As System.EventArgs)
            _TextBox.Focus()
        End Sub
    End Class
