    <Export>
    Public Class WhereAmI
      <Import>
      Public Person as person
    
      <Import>
      Public Place as place
    
      Public Sub TellMe()
            Console.WriteLine(person.Name & " is in " & place.Name)
      End Sub
    End Class
