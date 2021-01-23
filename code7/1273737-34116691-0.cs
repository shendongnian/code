    Imports System.IO
    Imports System.Threading
    Imports System.Threading.Tasks
    
    Module Module1
    
        Dim RemoteComputer As New List(Of String)
        Const FILENAME As String = "c:\temp\test.txt"
    
        Sub Main()
            Dim reader As New StreamReader(FILENAME)
            While reader.EndOfStream = False
                RemoteComputer.Add(reader.ReadLine)
            End While
            Parallel.ForEach(Of String)(RemoteComputer,
                                        Sub(ComputerName As String)
                                            Try
                                                Dim IPAddress As String = ComputerName.ToString.Substring(0, 13).ToString()
                                                Dim CName As String = ComputerName.ToString.Substring(14, 6).ToString()
                                                Dim ZipToCreate As String = "\\" & IPAddress & "\C$\temp\Test-" & CName & ".zip"
                                                If My.Computer.Network.Ping(Trim(IPAddress.ToString())) Then
                                                    Using zip As ZipFile = New ZipFile
                                                        Dim filenames As String() = System.IO.Directory.GetFiles("\\" & IPAddress & "\C$\Sample\")
                                                        For Each file In filenames
                                                            zip.AddFile(file, "")
                                                        Next
                                                        zip.Save(ZipToCreate)
                                                        File.Copy("\\" & IPAddress & "\C$\temp\Test-" & CName & ".zip", "\\destSeverIP\C$\Temp\Test-" & CName & ".zip", True)
                                                        Console.WriteLine("File copied successfully.....")
                                                    End Using
                                                Else
                                                    Console.WriteLine("Remote machine is not reachable")
                                                End If
                                            Catch ex As Exception
                                                Console.Error.WriteLine(ex.Message.ToString())
                                            Finally
                                                Console.ReadLine()
                                            End Try
                                        End Sub)
        End Sub
    End Module
