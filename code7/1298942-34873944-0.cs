      Private Sub ListView_MouseMove(sender As Object, e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            Dim viewModel As QuestionAnswerViewModel = CType(DataContext, QuestionAnswerViewModel)
            If e.LeftButton = MouseButtonState.Pressed And viewModel IsNot Nothing AndAlso viewModel.Value IsNot Nothing _
                    AndAlso Not e.OriginalSource().GetType().Equals(GetType(Thumb)) Then
                Dim data As New DataObject
                data.SetData(DataFormats.StringFormat, viewModel.Value)
                DragDrop.DoDragDrop(Me, data, DragDropEffects.Copy Or DragDropEffects.Move)
            End If
        End Sub
