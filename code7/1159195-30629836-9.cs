    Imports System.Management
    Imports System.Collections.Concurrent
    Imports System.Threading.Tasks
    
    Dim wql As String() = {"SELECT SerialNumber FROM Win32_BaseBoard",
                                   "SELECT Name FROM Win32_BIOS",
                                   "SELECT VideoProcessor FROM Win32_VideoController",
                                   "SELECT RegisteredUser FROM Win32_OperatingSystem"}
    
    Dim tasks As New List(Of Task)
    For Each q In wql
        Dim t As task = Task.Run(Sub()
                                     Dim str = WMI.GetWMIClassProperty(q)
                                     wList.Add(str)
                                 End Sub
        )
        tasks.Add(t)
    Next
    Task.WaitAll(tasks.ToArray)
