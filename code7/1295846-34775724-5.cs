    Module StartupModule
    
        Sub Main()
            Dim l1 As Level1 = New Level3
            l1.Print()
    
            Console.WriteLine()
    
            Dim l2 As Level2 = New Level3
            l2.Print()
    
            Console.WriteLine()
    
            Dim l3 As Level3 = New Level3
            l3.Print()
    
            Console.ReadLine()
        End Sub
    
    
        Public Class Level1
            Public Sub Print()
                Console.WriteLine("Level1.Print")
            End Sub
        End Class
    
        Public Class Level2
            Inherits Level1
    
            Public Overloads Sub Print()
                Console.WriteLine("Level2.Print")
            End Sub
        End Class
    
        Public Class Level3
            Inherits Level2
    
            Public Overloads Sub Print()
                MyBase.Print()
            End Sub
        End Class
    
    End Module
