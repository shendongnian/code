    Public Class WhereVisitor
        Inherits ExpressionVisitor
        Public Shared Function Stringify(expression As Expression) As String
            Dim visitor As New WhereVisitor()
            visitor.Visit(expression)
            Return visitor.Value
        End Function
        Public Sub New()
            Me._value = New StringBuilder()
        End Sub
        Private _value As StringBuilder
        Public ReadOnly Property Value() As String
            Get
                Return Me._value.ToString()
            End Get
        End Property
        Protected Overrides Function VisitBinary(node As BinaryExpression) As Expression
            ' node.Left and node.Right is not always of this type
            ' you have to check the type and maybe use another visitor 
            ' to obtain the information you want
            Dim left As MemberExpression = CType(node.Left, MemberExpression)
            Dim right As ConstantExpression = CType(node.Right, ConstantExpression)
            Me._value.AppendLine(String.Format("{0} = {1}", left.Member.Name, right.Value))
            Return MyBase.VisitBinary(node)
        End Function
    End Class
