    Public Class DocumentHeaderTemplateSelector
      Inherits DataTemplateSelector
      Public Property DocumentTemplate As DataTemplate
      Public Property ToolWindowTemplate As DataTemplate
      Public Overrides Function SelectTemplate(item As Object, container As System.Windows.DependencyObject) As System.Windows.DataTemplate
        Dim itemAsLayoutContent = TryCast(item, Xceed.Wpf.AvalonDock.Layout.LayoutContent)
        If TypeOf item Is Xceed.Wpf.AvalonDock.Layout.LayoutDocument AndAlso TypeOf DirectCast(item, Xceed.Wpf.AvalonDock.Layout.LayoutDocument).Content Is DocumentVM Then
          Return DocumentTemplate
        Else
          Return ToolWindowTemplate
        End If
      End Function
    End Class
