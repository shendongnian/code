     Public Shared Function HTMLEncodeSpecialChars(text As String) As String
        Dim sb As New System.Text.StringBuilder()
        If text IsNot Nothing Then
            For Each c As Char In text
                sb.Append([String].Format("&#{0};", AscW(c)))
                'If Not [Char].IsLetterOrDigit(c) Then
                '    ' special chars
                '    sb.Append([String].Format("&#{0};", AscW(c)))
                'Else
                '    sb.Append(c)
                'End If
            Next
        End If
        Return sb.ToString()
    End Function
