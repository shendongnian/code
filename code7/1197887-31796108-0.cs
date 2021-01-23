    Imports System.Runtime.InteropServices
    
    Public Class SymbolicLinker
    
        Public Enum SymbolicLink
            File = 0
            Directory = 1
        End Enum
    
        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function CreateSymbolicLink(lpSymlinkFileName As String, _
                                                  lpTargetFileName As String, _
                                                  dwFlags As SymbolicLink) As Boolean
        End Function
    
    End Class
    
    Module Module1
    
        Sub Main()
            CreateNewSymbolicLink("C:\Users\xxx\Desktop\link.txt", _
                                  "C:\Users\xxx\Desktop\foo.txt")
            Console.ReadKey()
        End Sub
    
        Sub CreateNewSymbolicLink(linkName As String, targetName As String)
            If Not SymbolicLinker.CreateSymbolicLink(linkName, targetName, _
                                                     SymbolicLinker.SymbolicLink.File) Then
                Console.WriteLine(Marshal.GetLastWin32Error())
            End If
        End Sub
    
    End Module
