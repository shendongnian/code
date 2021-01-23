    Public Class MyForm
        Private _BindingModel As MIConfig
    
        Public Sub New(model As MIConfig)
            Me.InitializeComponent()
            _BindingModel = model
            
           TextBox1.DataBinding.Add("Text", _BindingModel, "m_name", True)
            
        End Sub
       
    End Class
