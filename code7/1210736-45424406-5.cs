    Public Sub AnimateProperty(Obj As DependencyObject, PropPath As String, StartValue As Double, EndValue As Double, Optional PeriodMS As Integer = 350)
        Dim Storya As New Storyboard
        Dim DA1 As New DoubleAnimationUsingKeyFrames With {.BeginTime = New TimeSpan(0, 0, 0)}
        Storyboard.SetTarget(DA1, Obj)
        Storyboard.SetTargetProperty(DA1, PropPath)
        Dim ddkf1 As New DiscreteDoubleKeyFrame With {.KeyTime = New TimeSpan(0, 0, 0), .Value = StartValue}
        Dim edkf1 As New EasingDoubleKeyFrame With {.Value = EndValue, .KeyTime = New TimeSpan(0, 0, 0, 0, PeriodMS)}
        Dim pe1 As New PowerEase With {.EasingMode = EasingMode.EaseIn}
        edkf1.EasingFunction = pe1
        DA1.KeyFrames.Add(ddkf1)
        DA1.KeyFrames.Add(edkf1)
        Storya.Children.Add(DA1)
        Storya.Begin()
    End Sub
