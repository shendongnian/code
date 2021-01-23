    Dim managedComputer As New ManagedComputer()
    Dim sqlService As Service
    sqlService = managedComputer.Services("MSSQLSERVER")
    If sqlService.ServiceState = ServiceState.Stopped Then
        sqlService.Start()
    End If
