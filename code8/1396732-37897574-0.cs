    Imports System.Management 
    
    Public Class Form1
        
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
            Dim proc_query As String = "SELECT * FROM Win32_PhysicalMemory"
            Dim proc_searcher As New ManagementObjectSearcher(proc_query)
            For Each info As ManagementObject In proc_searcher.Get()
                textbox1.Text = "Speed of Your RAM is  " & info.Properties("Speed").Value.ToString()
            Next info
    
    
        End Sub
    End Class
