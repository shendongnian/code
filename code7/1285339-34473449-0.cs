    Public Enum UndoRedoCommand As Integer
        Undo
        Redo
    End Enum
    
    Public Class UndoRedoItem
        Public Property [Event] As Integer
        Public Property LastValue As Object
        Public Property CurrentValue As Object
    End Class
    
    Public MustInherit Class UndoRedo(Of T As Control)
    
    #Region " Private Fields "
    
        Private ReadOnly undoStack As Stack(Of UndoRedoItem)
        Private ReadOnly redoStack As Stack(Of UndoRedoItem)
    
    #End Region
    
    #Region " Properties "
    
        Public ReadOnly Property Control As T
            Get
                Return Me.controlB
            End Get
        End Property
        Protected WithEvents controlB As T
    
        Public ReadOnly Property CanUndo As Boolean
            Get
                Return (Me.undoStack.Count <> 0)
            End Get
        End Property
    
        Public ReadOnly Property CanRedo As Boolean
            Get
                Return (Me.redoStack.Count <> 0)
            End Get
        End Property
    
        Public ReadOnly Property IsUndoing As Boolean
            Get
                Return Me.isUndoingB
            End Get
        End Property
        Private isUndoingB As Boolean
    
        Public ReadOnly Property IsRedoing As Boolean
            Get
                Return Me.isRedoingB
            End Get
        End Property
        Private isRedoingB As Boolean
    
    #End Region
    
    #Region " Constructors "
    
        Private Sub New()
        End Sub
    
        Public Sub New(ByVal ctrl As T)
    
            Me.undoStack = New Stack(Of UndoRedoItem)
            Me.redoStack = New Stack(Of UndoRedoItem)
    
            Me.controlB = ctrl
    
        End Sub
    
    #End Region
    
    #Region " Public Methods "
    
        Public Sub Undo()
    
            If (Me.CanUndo) Then
                Me.InternalUndoRedo(UndoRedoCommand.Undo)
            End If
    
        End Sub
    
        Public Sub Redo()
    
            If (Me.CanRedo) Then
                Me.InternalUndoRedo(UndoRedoCommand.Redo)
            End If
    
        End Sub
    
    #End Region
    
    #Region " Private Methods "
    
        Private Sub InternalUndoRedo(ByVal command As UndoRedoCommand)
    
            Dim undoRedoItem As UndoRedoItem = Nothing
    
            Select Case command
    
                Case UndoRedoCommand.Undo
                    Me.isUndoingB = True
                    undoRedoItem = Me.undoStack.Pop
                    Me.AddUndoRedoItem(UndoRedoCommand.Redo, undoRedoItem.Event, undoRedoItem.LastValue, undoRedoItem.CurrentValue)
    
                Case UndoRedoCommand.Redo
                    Me.isRedoingB = True
                    undoRedoItem = Me.redoStack.Pop
    
            End Select
    
            Me.DoUndo(undoRedoItem.Event, undoRedoItem.CurrentValue)
    
            Me.isUndoingB = False
            Me.isRedoingB = False
    
        End Sub
    
        Protected MustOverride Sub DoUndo(ByVal [event] As Integer, ByVal data As Object)
    
        Protected Sub AddUndoRedoItem(ByVal command As UndoRedoCommand,
                                      ByVal [event] As Integer,
                                      ByVal currentData As Object,
                                      ByVal lastData As Object)
    
            Dim undoRedoItem As New UndoRedoItem
            undoRedoItem.Event = [event]
    
            Select Case command
    
                Case UndoRedoCommand.Undo
    
                    If (Me.isUndoingB) Then
                        Exit Select
                    End If
    
                    If (Me.CanUndo) AndAlso (Me.CanRedo) AndAlso Not (Me.IsRedoing) Then
                        Me.redoStack.Clear()
                    End If
    
                    undoRedoItem.CurrentValue = lastData
                    undoRedoItem.LastValue = currentData
                    Me.undoStack.Push(undoRedoItem)
    
                Case UndoRedoCommand.Redo
    
                    If (Me.isRedoingB) Then
                        Exit Select
                    End If
    
                    undoRedoItem.CurrentValue = currentData
                    undoRedoItem.LastValue = lastData
                    Me.redoStack.Push(undoRedoItem)
    
            End Select
    
        End Sub
    
    #End Region
    
    End Class
