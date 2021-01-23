    Partial Public Class MainPage
        Inherits UserControl
    
        Private _viewModel As TestViewModel
    
        Public Sub New()
            InitializeComponent()
            _viewModel = TryCast(Resources("TheViewModel"), TestViewModel)
            Me.DataContext = _viewModel
        End Sub
    End Class
