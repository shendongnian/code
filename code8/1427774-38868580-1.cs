    Imports System.Runtime.InteropServices
    Public Class Form1
        Sub New()
            InitializeComponent()
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End Sub
        Private Const WS_SYSMENU As Integer = &H80000
        Private Const WS_MINIMIZEBOX As Integer = &H20000
        Private Const WS_MAXIMIZEBOX As Integer = &H10000
        Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
            Get
                Dim p = MyBase.CreateParams
                p.Style = WS_SYSMENU + WS_MINIMIZEBOX + WS_MAXIMIZEBOX
                Return p
            End Get
        End Property
    
        <DllImport("user32.dll")>
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, _
            ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        Private Const WM_POPUPSYSTEMMENU As Integer = &H313
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim p = MousePosition.X + (MousePosition.Y * &H10000)
            SendMessage(Me.Handle, WM_POPUPSYSTEMMENU, 0, p)
        End Sub
    End Class
