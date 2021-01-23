    'Imports System.Security.Permissions
    'Imports System.Runtime.InteropServices
    
    
      Private first_point As New Point()
      Private second_point As New Point()
      Private iArguments As Integer = 0
      Private Const ULL_ARGUMENTS_BIT_MASK As Int64 = &HFFFFFFFFL
      Private Const WM_GESTURENOTIFY As Integer = &H11A
      Private Const WM_GESTURE As Integer = &H119
      Private Const GC_ALLGESTURES As Integer = &H1
      Private Const GID_BEGIN As Integer = 1
      Private Const GID_END As Integer = 2
      Private Const GID_ZOOM As Integer = 3
      Private Const GID_PAN As Integer = 4
      Private Const GID_ROTATE As Integer = 5
      Private Const GID_TWOFINGERTAP As Integer = 6
      Private Const GID_PRESSANDTAP As Integer = 7
      Private Const GF_BEGIN As Integer = &H1
      Private Const GF_INERTIA As Integer = &H2
      Private Const GF_END As Integer = &H4
      Private Structure GESTURECONFIG
        Public dwID As Integer
        Public dwWant As Integer
        Public dwBlock As Integer
      End Structure
      Private Structure POINTS
        Public x As Short
        Public y As Short
      End Structure
      Private Structure GESTUREINFO
        Public cbSize As Integer
        Public dwFlags As Integer
        Public dwID As Integer
        Public hwndTarget As IntPtr
        <MarshalAs(UnmanagedType.Struct)>
        Friend ptsLocation As POINTS
        Public dwInstanceID As Integer
        Public dwSequenceID As Integer
        Public ullArguments As Int64
        Public cbExtraArgs As Integer
      End Structure
      <DllImport("user32")> _
      Private Shared Function SetGestureConfig(ByVal hWnd As IntPtr, ByVal dwReserved As Integer, ByVal cIDs As Integer, ByRef pGestureConfig As GESTURECONFIG, ByVal cbSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function
      <DllImport("user32")>
      Private Shared Function GetGestureInfo(ByVal hGestureInfo As IntPtr, ByRef pGestureInfo As GESTUREINFO) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function
      Private _gestureConfigSize As Integer
      Private _gestureInfoSize As Integer
      <SecurityPermission(SecurityAction.Demand)>
      Private Sub SetupStructSizes()
        _gestureConfigSize = Marshal.SizeOf(New GESTURECONFIG())
        _gestureInfoSize = Marshal.SizeOf(New GESTUREINFO())
      End Sub
      <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
      Protected Overrides Sub WndProc(ByRef m As Message)
        Dim handled As Boolean
        Select Case m.Msg
          Case WM_GESTURENOTIFY
            Dim gc As New GESTURECONFIG()
            gc.dwID = 0
            gc.dwWant = GC_ALLGESTURES
            gc.dwBlock = 0
            Dim bResult As Boolean = SetGestureConfig(Handle, 0, 1, gc, _gestureConfigSize)
            If Not bResult Then
              Throw New Exception("Error in execution of SetGestureConfig")
            End If
            handled = True
          Case WM_GESTURE
            handled = DecodeGesture(m)
          Case Else
            handled = False
        End Select
        MyBase.WndProc(m)
        If handled Then
          Try
            m.Result = New IntPtr(1)
          Catch excep As Exception
            Debug.Print("Could not allocate result ptr")
            Debug.Print(excep.ToString())
          End Try
        End If
      End Sub
      Private Function DecodeGesture(ByRef m As Message) As Boolean
        Dim gi As GESTUREINFO
        Try
          gi = New GESTUREINFO()
        Catch excep As Exception
          Debug.Print("Could not allocate resources to decode gesture")
          Debug.Print(excep.ToString())
          Return False
        End Try
        gi.cbSize = _gestureInfoSize
        If Not GetGestureInfo(m.LParam, gi) Then
          Return False
        End If
        Select Case gi.dwID
          Case GID_BEGIN, GID_END
          Case GID_TWOFINGERTAP
            'Receipt.Show()
            'Invalidate()
          Case GID_ZOOM
            Select Case gi.dwFlags
              Case GF_BEGIN
                iArguments = CInt(Fix(gi.ullArguments And
                ULL_ARGUMENTS_BIT_MASK))
                first_point.X = gi.ptsLocation.x
                first_point.Y = gi.ptsLocation.y
                first_point = PointToClient(first_point)
              Case Else
                second_point.X = gi.ptsLocation.x
                second_point.Y = gi.ptsLocation.y
                second_point = PointToClient(second_point)
                RaiseEvent GestureHappened(Me, New GestureEventArgs With {.Operation = Gestures.Pan, .FirstPoint = first_point, .SecondPoint = second_point})
                'Invalidate()
                'MsgBox("zoom")
            End Select
          Case GID_PAN
            Select Case gi.dwFlags
              Case GF_BEGIN
                first_point.X = gi.ptsLocation.x
                first_point.Y = gi.ptsLocation.y
                first_point = PointToClient(first_point)
              Case Else
                second_point.X = gi.ptsLocation.x
                second_point.Y = gi.ptsLocation.y
                second_point = PointToClient(second_point)
                RaiseEvent GestureHappened(Me, New GestureEventArgs With {.Operation = Gestures.Pan, .FirstPoint = first_point, .SecondPoint = second_point})
                'Invalidate()
                'MsgBox("pan")
            End Select
          Case GID_PRESSANDTAP
            'If gi.dwFlags = GF_BEGIN Then
            '  Invalidate()
            'End If
          Case GID_ROTATE
            'Select Case gi.dwFlags
            '  Case GF_BEGIN
            '    iArguments = 0
            '  Case Else
            '    first_point.X = gi.ptsLocation.x
            '    first_point.Y = gi.ptsLocation.y
            '    first_point = PointToClient(first_point)
            '    Invalidate()
            'End Select
        End Select
        Return True
      End Function
    
    
      Public Enum Gestures
        Pan
        Zoom
      End Enum
    
      Public Class GestureEventArgs
        Inherits EventArgs
        Public Property Operation As Gestures
        Public Property FirstPoint As Point
        Public Property SecondPoint As Point
      End Class
    
      Public Event GestureHappened(sender As Object, e As GestureEventArgs)
