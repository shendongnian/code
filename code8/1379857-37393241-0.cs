    Imports System.Runtime.InteropServices
    Imports mshtml
    Imports System.IO
    Public Class Form1
        Dim Wb As New System.Windows.Forms.WebBrowser
        Dim bStart As New Button
   
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Size = New Size(1350, 600)
            Me.Location = New Point(10, 40)
            bStart.Text = "go"
            bStart.Size = New Size(40, 20)
            bStart.Location = New Point(10, 10)
            AddHandler bStart.Click, AddressOf bStart_click
            Me.Controls.Add(bStart)
            Wb.Size = New Size(1350, 550)
            Wb.Location = New Point(10, 50)
            Wb.IsWebBrowserContextMenuEnabled = True
            Wb.AllowWebBrowserDrop = True
            Me.Controls.Add(Wb)
        End Sub
        Private Sub bStart_click()
            str = "http://google.com"
            Wb.Navigate(str)
            Do Until Wb.ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
            Loop
            Dim HtmlActiveElements As System.Windows.Forms.HtmlElementCollection
            HtmlActiveElements = Wb.Document.GetElementsByTagName("input")
            Dim myHtmlElement As System.Windows.Forms.HtmlElementCollection
            myHtmlElement = HtmlActiveElements.GetElementsByName("btnK")
            Dim MyPoint As New Point(myHtmlElement(0).OffsetRectangle.Left + myHtmlElement(0).OffsetRectangle.Width / 2, myHtmlElement(0).OffsetRectangle.Top + myHtmlElement(0).OffsetRectangle.Height / 2)
            Dim parentElement As System.Windows.Forms.HtmlElement
            parentElement = myHtmlElement(0).OffsetParent
            While parentElement IsNot Nothing
                MyPoint.X += parentElement.OffsetRectangle.Left
                MyPoint.Y += parentElement.OffsetRectangle.Top
                parentElement = parentElement.OffsetParent
            End While
            Dim controlLoc As Point = Me.PointToScreen(Wb.Location)
            controlLoc.X = controlLoc.X + MyPoint.X
            controlLoc.Y = controlLoc.Y + MyPoint.Y
            Cursor.Position = controlLoc
            MouseSimulator.ClickRightMouseButton()
        End Sub
    End Class
