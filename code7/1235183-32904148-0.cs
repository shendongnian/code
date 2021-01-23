                For Each p As Microsoft.Office.Interop.Outlook.ItemProperty In item.ItemProperties
                    Try
                        MsgBox(p.Name & "    " & p.Value.ToString())
                        'One of thousends of attributes
                    Catch e As System.Exception
                    End Try
                Next
