    Imports System.Collections.ObjectModel
    Imports System.ComponentModel
    Class MainWindow
    Public Sub New()
        InitializeComponent()
        Dim viewModel = New ViewModel
        viewModel.Texts = New ObservableCollection(Of String)
        viewModel.Texts.Add("Hello")
        viewModel.Texts.Add("World")
        viewModel.FontSizes = New ObservableCollection(Of Integer)
        viewModel.FontSizes.Add(8)
        viewModel.FontSizes.Add(16)
        viewModel.FontSizes.Add(32)
        viewModel.CurrentFontSize = viewModel.FontSizes.First
        Me.DataContext = viewModel
    End Sub
    End Class
    Public Class ViewModel
    Implements INotifyPropertyChanged
    Public Property Texts As ObservableCollection(Of String)
    Public Property FontSizes As ObservableCollection(Of Integer)
    Private _currentText As String
    Public Property CurrentText As String
        Get
            Return _currentText
        End Get
        Set(value As String)
            If value = _currentText Then Return
            _currentText = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentText"))
        End Set
    End Property
    Private _currentFontSize As Integer
    Public Property CurrentFontSize() As Integer
        Get
            Return _currentFontSize
        End Get
        Set(ByVal value As Integer)
            If _currentFontSize = value Then Return
            _currentFontSize = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentFontSize"))
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class
