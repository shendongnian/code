    Try
       Dim stiHeder As StiVariable = New StiVariable("Setings", "VarHeder", strHeder)
       StiIsSuing.Dictionary.Variables.Add(stiHeder)
       'StiIsSuing.Dictionary.Synchronize()
       StiIsSuing.Compile()
       StiIsSuing.Render()
       StiIsSuing.Show()
       'System.Threading.Thread.Sleep(1000)
    
    Catch ex As Exception
       MsgBox("Error show report" & vbNewLine & ex.Message)
    End Try
