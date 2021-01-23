    ' ***********************************************************************
    ' Author   : Elektro
    ' Modified : 18-March-2016
    ' ***********************************************************************
    
    #Region " Public Members Summary "
    
    #Region " Functions "
    
    ' OpenFile(String, Single, Integer, Boolean, Boolean) As Boolean
    ' SaveFile(String, Integer, Single, Integer, Integer) As Boolean
    
    ' GetPlaybackDelay() As Integer
    ' SetAbsoluteDelay(Integer, Integer, Integer) As Boolean
    
    ' GetFormatIndex(String) As Integer
    ' GetFormatInformation(Integer, StringBuilder, StringBuilder, Integer, Integer) As Boolean
    
    ' GetSubtitleLineCount() As Integer
    ' GetSubtitleLine(Integer, Integer, Integer, StringBuilder, Integer) As Boolean
    
    ' AddSubtitleLine(Integer, Integer, String) As Integer
    ' InsertSubtitleLine(Integer, Integer, Integer, String) As Boolean
    ' DeleteSubtitleLine(Integer) As Boolean
    ' CreateNewSubtitleLine()
    
    #End Region
    
    #Region " Methods "
    
    ' ClearSubtitleLines()
    ' CloseFile()
    ' GetCurrentFormatName(StringBuilder, Integer, Integer)
    ' GetFormatName(Integer, StringBuilder, Integer)
    ' GetSubtitleText(Integer, StringBuilder, Integer)
    ' SetPlaybackDelay(Integer)
    
    #End Region
    
    #End Region
    
    #Region " Option Statements "
    
    Option Strict On
    Option Explicit On
    Option Infer Off
    
    #End Region
    
    #Region " Imports "
    
    Imports System
    Imports System.Linq
    Imports System.Runtime.InteropServices
    Imports System.Security
    
    #End Region
    
    #Region " P/Invoke "
    
    Namespace SubtitleWorkshop.Interop
    
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Platform Invocation methods (P/Invoke), access unmanaged code.
        ''' <para></para>
        ''' This class suppresses stack walks for unmanaged code permission. 
        ''' <see cref="System.Security.SuppressUnmanagedCodeSecurityAttribute"/> is applied to this class.
        ''' <para></para>
        ''' This class is for methods that are safe for anyone to call.
        ''' <para></para>
        ''' Callers of these methods are not required to perform a full security review to make sure that the 
        ''' usage is secure because the methods are harmless for any caller.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/ms182161.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <SuppressUnmanagedCodeSecurity>
        Friend NotInheritable Class SafeNativeMethods
    
    #Region " Methods "
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Opens the specified subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="filepath">
            ''' The source subtitle filepath.
            ''' </param>
            ''' 
            ''' <param name="fps">
            ''' The subtitle FPS.
            ''' </param>
            ''' 
            ''' <param name="formatIndex">
            ''' The subtitle format index.
            ''' </param>
            ''' 
            ''' <param name="append">
            ''' If <see langword="True"/>, appends to the end of the subtitle file.
            ''' </param>
            ''' 
            ''' <param name="reCalcTimeValues">
            ''' If <see langword="True"/>, recalculates the time values of the subtitle.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the specified subtitle file was open successfully, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="LoadSubtitleFile", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function OpenFile(<MarshalAs(UnmanagedType.LPStr)> ByVal filepath As String,
                                            <MarshalAs(UnmanagedType.R4)> ByVal fps As Single,
                                            <MarshalAs(UnmanagedType.I4)> ByVal formatIndex As Integer,
                                            <MarshalAs(UnmanagedType.Bool)> ByVal append As Boolean,
                                            <MarshalAs(UnmanagedType.Bool)> ByVal reCalcTimeValues As Boolean
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Closes the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="CloseSubtitleFile", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub CloseFile()
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Saves (or converts) the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="filepath">
            ''' The target subtitle filepath.
            ''' </param>
            ''' 
            ''' <param name="formatIndex">
            ''' The target subtitle format.
            ''' </param>
            ''' 
            ''' <param name="fps">
            ''' The target subtitle FPS.
            ''' </param>
            ''' 
            ''' <param name="fromIndex">
            ''' The starting index to copy from the source subtitle lines.
            ''' </param>
            ''' 
            ''' <param name="toIndex">
            ''' The ending index to copy from the source subtitle lines.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="SaveSubtitleFile", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function SaveFile(<MarshalAs(UnmanagedType.LPStr)> ByVal filepath As String,
                                            <MarshalAs(UnmanagedType.I4)> ByVal formatIndex As Integer,
                                            <MarshalAs(UnmanagedType.R4)> ByVal fps As Single,
                                            <MarshalAs(UnmanagedType.I4)> ByVal fromIndex As Integer,
                                            <MarshalAs(UnmanagedType.I4)> ByVal toIndex As Integer
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the format index of the specified subtitle format name.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="formatName">
            ''' The name of the subtitle format.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' The subtitle format index.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetFormatIndex", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function GetFormatIndex(<MarshalAs(UnmanagedType.LPStr)> ByVal formatName As String
            ) As <MarshalAs(UnmanagedType.I4)> Integer
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the format name of the specified subtitle format index.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="formatIndex">
            ''' The index of the subtitle format.
            ''' </param>
            ''' 
            ''' <param name="buffer">
            ''' The string buffer to store the the subtitle format name.
            ''' </param>
            ''' 
            ''' <param name="refBufferLength">
            ''' A by-reference variable that indicates the length of <paramref name="buffer"/>.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetFormatName", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub GetFormatName(<MarshalAs(UnmanagedType.I4)> ByVal formatIndex As Integer,
                                            <MarshalAs(UnmanagedType.LPStr)> ByVal buffer As StringBuilder,
                                            <MarshalAs(UnmanagedType.I4)> ByRef refBufferLength As Integer
            )
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets information of the specified subtitle format index.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="formatIndex">
            ''' The index of the subtitle format.
            ''' </param>
            ''' 
            ''' <param name="bufferDescription">
            ''' The string buffer to store the the subtitle format description.
            ''' </param>
            ''' 
            ''' <param name="bufferExtensions">
            ''' The string buffer to store the the subtitle format extensions.
            ''' </param>
            ''' 
            ''' <param name="refBufferDescriptionLength">
            ''' A by-reference variable that indicates the length of <paramref name="bufferDescription"/>.
            ''' </param>
            ''' 
            ''' <param name="refBufferExtensionsLength">
            ''' A by-reference variable that indicates the length of <paramref name="bufferExtensions"/>.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetFormatInformation", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function GetFormatInformation(<MarshalAs(UnmanagedType.I4)> ByVal formatIndex As Integer,
                                                        <MarshalAs(UnmanagedType.LPStr)> ByVal bufferDescription As StringBuilder,
                                                        <MarshalAs(UnmanagedType.LPStr)> ByVal bufferExtensions As StringBuilder,
                                                        <MarshalAs(UnmanagedType.I4)> ByRef refBufferDescriptionLength As Integer,
                                                        <MarshalAs(UnmanagedType.I4)> ByRef refBufferExtensionsLength As Integer
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the subtitle format name of the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="buffer">
            ''' The string buffer to store the the subtitle format name.
            ''' </param>
            ''' 
            ''' <param name="refIndex">
            ''' A by-reference variable that stores the subtitle format name.
            ''' </param>
            ''' 
            ''' <param name="refBufferLength">
            ''' A by-reference variable that indicates the length of <paramref name="buffer"/>.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetCurrentFormat", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub GetCurrentFormatName(<MarshalAs(UnmanagedType.LPStr)> ByVal buffer As StringBuilder,
                                                   <MarshalAs(UnmanagedType.I4)> ByRef refIndex As Integer,
                                                   <MarshalAs(UnmanagedType.I4)> ByRef refBufferLength As Integer
            )
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the line count of the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' The line count.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetSubtitleCount", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function GetSubtitleLineCount(
            ) As <MarshalAs(UnmanagedType.I4)> Integer
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the subtitle text at the specified time on the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="time">
            ''' The time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="buffer">
            ''' The string buffer to store the the subtitle text.
            ''' </param>
            ''' 
            ''' <param name="refBufferLength">
            ''' A by-reference variable that indicates the length of <paramref name="buffer"/>.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetSubtitleText", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub GetSubtitleText(<MarshalAs(UnmanagedType.I4)> ByVal time As Integer,
                                              <MarshalAs(UnmanagedType.LPStr)> ByVal buffer As StringBuilder,
                                              <MarshalAs(UnmanagedType.I4)> ByRef refBufferLength As Integer
            )
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the subtitle text at the specified line of the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="lineIndex">
            ''' The line index.
            ''' </param>
            ''' 
            ''' <param name="refStartTime">
            ''' A by-reference variable that stores the starting subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="refEndTime">
            ''' A by-reference variable that stores the ending subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="buffer">
            ''' The string buffer to store the the subtitle text.
            ''' </param>
            ''' 
            ''' <param name="refBufferLength">
            ''' A by-reference variable that indicates the length of <paramref name="buffer"/>.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetSubtitle", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function GetSubtitleLine(<MarshalAs(UnmanagedType.I4)> ByVal lineIndex As Integer,
                                                   <MarshalAs(UnmanagedType.I4)> ByRef refStartTime As Integer,
                                                   <MarshalAs(UnmanagedType.I4)> ByRef refEndTime As Integer,
                                                   <MarshalAs(UnmanagedType.LPStr)> ByVal buffer As StringBuilder,
                                                   <MarshalAs(UnmanagedType.I4)> ByRef refBufferLength As Integer
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Sets an absolute delay on the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="time">
            ''' The delay, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="fromLineIndex">
            ''' The starting subtitle line index.
            ''' </param>
            ''' 
            ''' <param name="toLineIndex">
            ''' The ending subtitle line index.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="SetAbsoluteDelay", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function SetAbsoluteDelay(
                    <MarshalAs(UnmanagedType.I4)> ByVal time As Integer,
                    <MarshalAs(UnmanagedType.I4)> ByVal fromLineIndex As Integer,
                    <MarshalAs(UnmanagedType.I4)> ByVal toLineIndex As Integer
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the playback delay of the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' The playback delay, in milliseconds.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="GetPlaybackDelay", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function GetPlaybackDelay(
            ) As <MarshalAs(UnmanagedType.I4)> Integer
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Sets a playback delay on the current subtitle file.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="time">
            ''' The playback delay, in milliseconds.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="SetPlaybackDelay", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub SetPlaybackDelay(<MarshalAs(UnmanagedType.I4)> ByVal time As Integer)
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Adds a subtitle line at the specified time in the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="startTime">
            ''' The starting subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="endTime">
            ''' The ending subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="text">
            ''' The subtitle text.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' 
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="AddSubtitle", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function AddSubtitleLine(<MarshalAs(UnmanagedType.I4)> ByVal startTime As Integer,
                                                   <MarshalAs(UnmanagedType.I4)> ByVal endTime As Integer,
                                                   <MarshalAs(UnmanagedType.LPStr)> ByVal text As String
            ) As <MarshalAs(UnmanagedType.I4)> Integer
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Adds a subtitle line at the specified time in the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="lineIndex">
            ''' The index of the line where to insert the subtitle line.
            ''' </param>
            ''' 
            ''' <param name="startTime">
            ''' The starting subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="endTime">
            ''' The ending subtitle time, in milliseconds.
            ''' </param>
            ''' 
            ''' <param name="text">
            ''' The subtitle text.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="InsertSubtitle", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function InsertSubtitleLine(<MarshalAs(UnmanagedType.I4)> ByVal lineIndex As Integer,
                                                      <MarshalAs(UnmanagedType.I4)> ByVal endTime As Integer,
                                                      <MarshalAs(UnmanagedType.I4)> ByVal startTime As Integer,
                                                      <MarshalAs(UnmanagedType.LPStr)> ByVal text As String
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Removes a subtitle line in the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="lineIndex">
            ''' The index of the subtitle line to remove.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <returns>
            ''' <see langword="True"/> if the operation success, otherwise, <see langword="False"/>.
            ''' </returns>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="DeleteSubtitle", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Function DeleteSubtitleLine(<MarshalAs(UnmanagedType.I4)> ByVal lineIndex As Integer
            ) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Clears all the subtitle lines in the current subtitle file. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="ClearSubtitles", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub ClearSubtitleLines()
            End Sub
    
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Create a new subtitle. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <SuppressUnmanagedCodeSecurity>
            <DllImport("SubtitleAPI.dll", EntryPoint:="CreateNewSubtitle", SetLastError:=False, CharSet:=CharSet.Ansi)>
            Friend Shared Sub CreateNewSubtitleLine()
            End Sub
    
    #End Region
    
        End Class
    
    End Namespace
    
    #End Region
