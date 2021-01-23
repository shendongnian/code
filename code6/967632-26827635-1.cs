    Imports System.ComponentModel
    Imports DevExpress.XtraGrid.Localization
    Imports System.Windows.Forms
    Imports System.Drawing
    
    Public Class MirroredDevExpressGrid
       Private _Mirrored As Boolean
       Const WS_EX_LAYOUTRTL = &H400000
    
       Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
          Get
             Dim CP As System.Windows.Forms.CreateParams = _
                   MyBase.CreateParams
             If Mirrored Then
                CP.ExStyle = CP.ExStyle Or WS_EX_LAYOUTRTL
                MyBase.Refresh()
             End If
             Return CP
          End Get
       End Property
    
       <Description("Change to the right-to-left layout."), _
      DefaultValue(False), Localizable(True), _
      Category("Appearance"), Browsable(True)> _
       Public Property Mirrored() As Boolean
          Get
             Return _Mirrored
          End Get
          Set(ByVal value As Boolean)
             If _Mirrored <> value Then
                _Mirrored = value
                MyBase.OnRightToLeftChanged(EventArgs.Empty)
             End If
          End Set
       End Property
    
       Private Sub InitializeComponent()
          Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
          CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
          CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
          Me.SuspendLayout()
          Me.LookAndFeel.SetSkinStyle("Money Twins")
          Me.LookAndFeel.UseDefaultLookAndFeel = False
          Me.Mirrored = True
          '
          'GridView1
          '
          Me.GridView1.GridControl = Me
          Me.GridView1.Name = "GridView1"
          '
          'MirroredDevExpressGrid
          '
          Me.MainView = Me.GridView1
          Me.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
             CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
          CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
          Me.ResumeLayout(False)
    
       End Sub
    
    
       Private Sub MirroredDevExpressGrid_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
      
          Invalidate()
       End Sub
    
    End Class
    
    and in designer class:
    
    you can use ms trick:
    
    make new component and in code view add the following lines:
    
    Imports System.ComponentModel
    Imports DevExpress.XtraGrid.Localization
    Imports System.Windows.Forms
    Imports System.Drawing
    
    Public Class MirroredDevExpressGrid
       Private _Mirrored As Boolean
       Const WS_EX_LAYOUTRTL = &H400000
    
       Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
          Get
             Dim CP As System.Windows.Forms.CreateParams = _
                   MyBase.CreateParams
             If Mirrored Then
                CP.ExStyle = CP.ExStyle Or WS_EX_LAYOUTRTL
                MyBase.Refresh()
             End If
             Return CP
          End Get
       End Property
    
       <Description("Change to the right-to-left layout."), _
      DefaultValue(False), Localizable(True), _
      Category("Appearance"), Browsable(True)> _
       Public Property Mirrored() As Boolean
          Get
             Return _Mirrored
          End Get
          Set(ByVal value As Boolean)
             If _Mirrored <> value Then
                _Mirrored = value
                MyBase.OnRightToLeftChanged(EventArgs.Empty)
             End If
          End Set
       End Property
    
       Private Sub InitializeComponent()
          Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
          CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
          CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
          Me.SuspendLayout()
          Me.LookAndFeel.SetSkinStyle("Money Twins")
          Me.LookAndFeel.UseDefaultLookAndFeel = False
          Me.Mirrored = True
          '
          'GridView1
          '
          Me.GridView1.GridControl = Me
          Me.GridView1.Name = "GridView1"
          '
          'MirroredDevExpressGrid
          '
          Me.MainView = Me.GridView1
          Me.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
             CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
          CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
          Me.ResumeLayout(False)
    
       End Sub
    
    
       Private Sub MirroredDevExpressGrid_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
      
          Invalidate()
       End Sub
    
    End Class
    
    and in designer class:
    
    Partial Class MirroredDevExpressGrid
       Inherits DevExpress.XtraGrid.GridControl
    
       <System.Diagnostics.DebuggerNonUserCode()> _
     Protected Overrides Sub Dispose(ByVal disposing As Boolean)
          MyBase.Dispose(disposing)
       End Sub
       Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    
    End Class
