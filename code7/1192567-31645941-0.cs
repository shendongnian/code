    getCity
    {user => user.Address.City}
        Body: {user.Address.City}
        CanReduce: false
        DebugView: ".Lambda #Lambda1<System.Func`2[ConsoleApplication1.User,System.String]>(ConsoleApplication1.User $user) {\r\n    ($user.Address).City\r\n}"
        Name: null
        NodeType: Lambda
        Parameters: Count = 1
        ReturnType: {Name = "String" FullName = "System.String"}
        TailCall: false
