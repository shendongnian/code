    <Export>
    Public Class WhereAmI
      <Import>
      Public person as Person
    
      <Import>
      Public place as Place
    
      Public Sub TellMe()
            Console.WriteLine(person.Name & " is in " & place.Name)
      End Sub
    End Class
