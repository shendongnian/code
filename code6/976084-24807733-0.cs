    Imports System.Runtime.InteropServices
    Imports System.ComponentModel
    Public Class Form1
        Private Sub HandleLoad(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim [error] As Exception = Nothing
            Dim initialized As Boolean = False
            Dim hProcess As IntPtr = Nothing
            Try
                SymSetOptions(2 Or 4)
                hProcess = Process.GetCurrentProcess().Handle
                If (SymInitialize(hProcess, Nothing, True)) Then
                    initialized = True
                Else
                    Throw New Win32Exception(Marshal.GetLastWin32Error())
                End If
                Dim baseOfDll As IntPtr = SymLoadModuleEx(hProcess, IntPtr.Zero, (Environment.SystemDirectory & "\gdi32.dll"), Nothing, 0, 0, IntPtr.Zero, &H0I)
                If (baseOfDll = IntPtr.Zero) Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error())
                End If
                If Not SymEnumSymbols(
                    hProcess,
                    baseOfDll,
                    "*",
                    Function(pSymInfo As IntPtr, SymbolSize As UInteger, UserContext As IntPtr)
                        Dim struct As New SYMBOL_INFO
                        struct.SizeOfStruct = Marshal.SizeOf(GetType(SYMBOL_INFO))
                        Marshal.PtrToStructure(pSymInfo, struct)
                        Debug.WriteLine(struct.Name)
                        Return True
                    End Function, IntPtr.Zero
                ) Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error())
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            Finally
                If (initialized) Then
                    SymCleanup(hProcess)
                End If
            End Try
        End Sub
        <DllImport("dbghelp.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function SymSetOptions(ByVal SymOptions As Integer) As Integer
        End Function
        <DllImport("dbghelp.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function SymInitialize(ByVal hProcess As IntPtr, ByVal UserSearchPath As String, <MarshalAs(UnmanagedType.Bool)> ByVal fInvadeProcess As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("dbghelp.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function SymCleanup(ByVal hProcess As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("dbghelp.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function SymLoadModuleEx(ByVal hProcess As IntPtr, ByVal hFile As IntPtr, ByVal ImageName As String, ByVal ModuleName As String, ByVal BaseOfDll As Long, ByVal DllSize As Integer, ByVal Data As IntPtr, ByVal Flags As Integer) As ULong
        End Function
        <DllImport("dbghelp.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function SymEnumSymbols(ByVal hProcess As IntPtr, ByVal BaseOfDll As ULong, ByVal Mask As String, ByVal EnumSymbolsCallback As SymEnumSymbolsProc, ByVal UserContext As IntPtr) As Boolean '  As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        Private Delegate Function SymEnumSymbolsProc(pSymInfo As IntPtr, ByVal SymbolSize As UInteger, ByVal UserContext As IntPtr) As Boolean
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
        Private Class SYMBOL_INFO
            Public SizeOfStruct As UInteger
            Public TypeIndex As UInteger
            Public Reserved1 As ULong
            Public Reserved2 As ULong
            Public Index As UInteger
            Public Size As UInteger
            Public ModBase As ULong
            Public Flags As UInteger
            Public Value As ULong
            Public Address As ULong
            Public Register As UInteger
            Public Scope As UInteger
            Public Tag As UInteger
            Public NameLen As UInteger
            Public MaxNameLen As UInteger
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1024)> Public Name As String
        End Class
    End Class
