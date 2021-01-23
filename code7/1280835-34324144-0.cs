    Imports System
    Imports System.Windows.Forms
    Public Class WizardPages
      Inherits TabControl
      Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H1328 AndAlso Not DesignMode Then
          m.Result = new IntPtr(1)
        Else
          MyBase.WndProc(m)
        End If
      End Sub
      
      Protected Overrides Sub OnKeyDown(ke As KeyEventArgs)
        ' Block Ctrl+Tab and Ctrl+Shift+Tab hotkeys
        If ke.Control AndAlso ke.KeyCode = Keys.Tab Then Return
        MyBase.OnKeyDown(ke)
      End Sub
    End Class
