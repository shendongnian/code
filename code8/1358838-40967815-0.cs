    Dim CertDataInfo As System.Security.Cryptography.X509Certificates.X509Certificate2 
    Dim Store As New System.Security.Cryptography.X509Certificates.X509Store("MY", Security.Cryptography.X509Certificates.StoreLocation.CurrentUser)
    
    Store.Open(Security.Cryptography.X509Certificates.OpenFlags.ReadOnly)
    Console.writeline (Store.Certificates.Count)
    
    For I = 0 To Store.Certificates.Count - 1
     If Store.Certificates.Item(I).FriendlyName = "Heider Sati's Cert(48F57XTHVE)" Then
      CertDataInfo = Store.Certificates.Item(I)
     End If
    
     Console.writeline ("Cert: " & Store.Certificates.Item(I).FriendlyName)
         
    Next
    Store.Close()
    
    If CertDataInfo.PrivateKey Is Nothing Then
     MsgBox("NULL")
    Else
     MsgBox("YES")
    End If
