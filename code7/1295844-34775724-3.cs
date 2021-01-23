    Module StartupModule
    
        Sub Main()
            Dim l1 As Level1 = New Level3
            l1.Print()
            l1.Print(10)
    
            Console.WriteLine()
    
            Dim l2 As Level2 = New Level3
            l2.Print()
            l2.Print("20")
    
            Console.WriteLine()
    
            Dim l3 As Level3 = New Level3
            l3.Print()
            l3.Print(DateTime.Now)
    
            Console.ReadLine()
        End Sub
    
    
        Public Class Level1
            Public Overloads Sub Print()
                Console.WriteLine("Level1.Print")
            End Sub
    
            Public Overloads Sub Print(value As Integer)
                Console.WriteLine("Level1.Print(Value)={0}", value)
            End Sub
        End Class
    
        Public Class Level2
            Inherits Level1
    
            Public Shadows Sub Print()
                Console.WriteLine("Level2.Print")
            End Sub
    
            Public Shadows Sub Print(value As String)
                Console.WriteLine("Level2.Print(Value)={0}", value & "1")
            End Sub
        End Class
    
        Public Class Level3
            Inherits Level2
    
            Public Shadows Sub Print()
                MyBase.Print()
            End Sub
    
            Public Shadows Sub Print(value As DateTime)
                Console.WriteLine("Level3.Print(Value)={0}", value)
            End Sub
        End Class
    
    End Module
