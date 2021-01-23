    Imports System
    Imports System.Text
    Public Module Module1
        Public Sub Main()
            Dim str As String = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            Console.WriteLine(GrabRandSequence(str))
            Console.WriteLine(GrabRandSequence(str))
            Console.WriteLine(GrabRandSequence(str))
            Console.ReadKey()
        End Sub
    
        Public Function GrabRandSequence(inputstr As String)
            Try
                Dim words As String() = inputstr.Split(New Char() {" "c})
                Dim index As Integer
                index = CInt(Math.Floor((words.Length - 5) * Rnd()))
                Return [String].Join(" ", words, index, 5)
    
            Catch e As Exception
                Return e.ToString()
            End Try
        End Function    
    End Module
