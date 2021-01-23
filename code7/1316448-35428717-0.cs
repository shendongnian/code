            Sub DoStuff()
                Dim obj As d = New d()
                Dim data As PropertyInfo = obj.GetType().GetProperty(GetPropertyName(Function() obj.EntityID), BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim x = data.GetValue(obj, Nothing)
            End Sub
            Public Function GetPropertyName(Of T)(prop As Expression(Of Func(Of T))) As String
                Dim expression = GetMemberInfo(prop)
                Return expression.Member.Name
            End Function
            Private Function GetMemberInfo(method As Expression) As MemberExpression
                Dim lambda As LambdaExpression = TryCast(method, LambdaExpression)
                If lambda Is Nothing Then
                    Throw New ArgumentNullException("method")
                End If
    
                Dim memberExpr As MemberExpression = Nothing
    
                If lambda.Body.NodeType = ExpressionType.Convert Then
                    memberExpr = TryCast(DirectCast(lambda.Body, UnaryExpression).Operand, MemberExpression)
                ElseIf lambda.Body.NodeType = ExpressionType.MemberAccess Then
                    memberExpr = TryCast(lambda.Body, MemberExpression)
                End If
    
                If memberExpr Is Nothing Then
                    Throw New ArgumentException("method")
                End If
    
                Return memberExpr
            End Function
