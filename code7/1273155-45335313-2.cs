    Module Module1
        Private ReadOnly SetSelectedTextInternal As Action(Of TextBox, String, Boolean) =
            DirectCast([Delegate].CreateDelegate(GetType(Action(Of TextBox, String, Boolean)),
                                             GetType(TextBox).GetMethod("SetSelectedTextInternal",
                                             BindingFlags.Instance Or BindingFlags.NonPublic)),
                                             Action(Of TextBox, String, Boolean))
        <Extension>
        Public Sub Delete(target As TextBox)
            If String.IsNullOrEmpty(target.Text) Then Return
            'target.SelectAll()
            SetSelectedTextInternal(target, String.Empty, False)
        End Sub
    End Module
