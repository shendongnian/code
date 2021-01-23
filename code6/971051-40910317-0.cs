    Private Class getList(Of T As Class)
        Public Shared Function getList() As List(Of T)
            Using ctx As New MVPBTEntities()
                ' Get the DbSet of the type T from the entities model (i.e. DB)
                Dim dbSet = ctx.Set(Of T)()
                Return dbSet.ToList
            End Using
        End Function
    End Class
