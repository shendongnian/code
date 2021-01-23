        ''' <summary>
        ''' Returns the control and all descendants as a sequence
        ''' </summary>
        <Extension>
        Public Iterator Function AsEnumerable(control As Control) As IEnumerable(Of Control)
            Dim queue = New Queue(Of Control)
            queue.Enqueue(control)
            Do While queue.Count <> 0
                control = queue.Dequeue()
                Yield control
                For Each c As Control In control.Controls
                    queue.Enqueue(c)
                Next
            Loop
        End Function
        <Extension>
        Public Sub SetInputControlsToReadonly(control As Control)
            control.AsEnumerable().Each(Sub(c)
                                            If TypeOf c Is TextBox Then DirectCast(c, TextBox).ReadOnly = True
                                            If TypeOf c Is ListControl Then DirectCast(c, ListControl).Enabled = False
                                        End Sub)
        End Sub
