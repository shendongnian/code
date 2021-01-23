    Public Sub GetImageButton(ByVal plh as PlaceHolder, ByVal id As String) As ImageButton
      Dim btn As New ImageButton
      btn.ID = id
      ...
      plh.Controls.Add(btn)
    End Sub
