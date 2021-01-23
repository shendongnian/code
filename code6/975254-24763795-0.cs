    Public Class UIComboBox
        Inherits ComboBox
         
        Private Sub NotifyAdded(index As Integer)
        End Sub
        Private Sub NotifyCleared()
        End Sub
        Private Sub NotifyInserted(index As Integer)
        End Sub
        Private Sub NotifyRemoved(index As Integer)
        End Sub
        Protected Overrides Sub WndProc(ByRef m As Message)
            Select Case m.Msg
                Case CB_ADDSTRING
                    MyBase.WndProc(m)
                    Dim index As Integer = (Me.Items.Count - 1)
                    Me.NotifyAdded(index)
                    Exit Select
                Case CB_DELETESTRING
                    MyBase.WndProc(m)
                    Dim index As Integer = m.WParam.ToInt32()
                    Me.NotifyRemoved(index)
                    Exit Select
                Case CB_INSERTSTRING
                    MyBase.WndProc(m)
                    Dim index As Integer = m.WParam.ToInt32()
                    Me.NotifyAdded(If((index > -1), index, (Me.Items.Count - 1)))
                    Exit Select
                Case CB_RESETCONTENT
                    MyBase.WndProc(m)
                    Me.NotifyCleared()
                    Exit Select
                Case Else
                    MyBase.WndProc(m)
                    Exit Select
            End Select
        End Sub
        Private Const CB_ADDSTRING As Integer = &H143
        Private Const CB_DELETESTRING As Integer = &H144
        Private Const CB_INSERTSTRING As Integer = 330
        Private Const CB_RESETCONTENT As Integer = &H14B
    End Class
