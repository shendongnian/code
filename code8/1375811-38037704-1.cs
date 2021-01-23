    Public Shared Function Create(DbContext As DbContext) As YourDBname
        Dim _txoptions As New TransactionOptions()
        _txoptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
        Dim _tx = New Transactions.TransactionScope(TransactionScopeOption.RequiresNew, _txoptions)
        Return New YourDB(DbContext)
    End Function
