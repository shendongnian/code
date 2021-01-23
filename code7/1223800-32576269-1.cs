      Public Function FormatFilteredName(mainFilter As String, subFilter As String) As TextBlock
            ' Dim tbNew As New TextBlock(New Run("111xxJoe Blogs09"))
            ' tbNew.Text = "111xxJoe Blogs09"
            ' tbNew.FontSize = 10
            If Not String.IsNullOrEmpty(tbNew.Text) Then
                If Not String.IsNullOrEmpty(mainFilter) Then
                    Dim mainFilterRange As TextRange = FindWordFromPosition(tbNew.ContentStart, mainFilter)
                    If mainFilterRange IsNot Nothing Then
                        ApplyStrikeOutStyle(mainFilterRange)
                    End If
                End If
                If Not String.IsNullOrEmpty(subFilter) Then
                    Dim subFilterRange As TextRange = FindWordFromPosition(tbNew.ContentStart, subFilter)
                    If subFilterRange IsNot Nothing Then
                        ApplyStrikeOutStyle(subFilterRange)
                    End If
                End If
            End If
            Return tbNew
        End Function
    
    
    
        Private Function ApplyStrikeOutStyle(result As TextRange) As TextRange
            result.ApplyPropertyValue(Inline.TextDecorationsProperty,
                                 TextDecorations.Strikethrough)
            Return result
        End Function
    
    
        Private Function FindWordFromPosition(position As TextPointer, word As String) As TextRange
            While position IsNot Nothing
                If position.GetPointerContext(LogicalDirection.Forward) = TextPointerContext.Text Then
                    Dim textRun As String = position.GetTextInRun(LogicalDirection.Forward)
    
                    ' Find the starting index of any substring that matches "word".
                    Dim indexInRun As Integer = textRun.IndexOf(word)
                    If indexInRun >= 0 Then
                        Dim start As TextPointer = position.GetPositionAtOffset(indexInRun)
                        Dim [end] As TextPointer = start.GetPositionAtOffset(word.Length)
                        Return New TextRange(start, [end])
                    End If
                End If
    
                position = position.GetNextContextPosition(LogicalDirection.Forward)
            End While
    
            ' position will be null if "word" is not found.
            Return Nothing
        End Function
    
    
