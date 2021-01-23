    Sub SaveAllFiles()
        For i = 1 To DTE.Solution.Projects.Count
            If Not DTE.Solution.Projects.Item(i).Saved Then
                DTE.Solution.Projects.Item(i).Save()
            End If
            For j = 1 To DTE.Solution.Projects.Item(i).ProjectItems.Count
                If Not DTE.Solution.Projects.Item(i).ProjectItems.Item(j).Saved Then
                    DTE.Solution.Projects.Item(i).ProjectItems.Item(j).Save()
                End If
            Next
        Next 
    End Sub
