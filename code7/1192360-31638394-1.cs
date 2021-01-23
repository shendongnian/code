    Private Sub ReadInput(animal As Animal)
        Dim mammal As Mammal = TryCast(animal, Mammal)
        If mammal IsNot Nothing Then
            mammal.Teeth = ReadTeeth()
        End If
    End Sub
