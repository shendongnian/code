    Namespace MyOrg
    
    
        Public Class CryptStrings
            Protected Shared strKey As String = "lalalalala"
            Protected Shared TripleDESprovider As New System.Security.Cryptography.TripleDESCryptoServiceProvider
            Protected Shared MD5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider
    
    
            ' COR.CryptStrings.DeCrypt("abc")
            Public Shared Function DeCrypt(ByVal strSourceText As String) As String
                Dim strReturnValue As String = Nothing
    
                Try
                    TripleDESprovider.Key = MD5Hasher.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey))
                    TripleDESprovider.Mode = System.Security.Cryptography.CipherMode.ECB
                    If Not strSourceText = "" Then
                        Dim DESdecryptor As System.Security.Cryptography.ICryptoTransform = TripleDESprovider.CreateDecryptor()
                        Dim baBuffer() As Byte = Convert.FromBase64String(strSourceText)
                        TripleDESprovider.Clear()
                        'DESdecryptor.Dispose()
                        strReturnValue = System.Text.ASCIIEncoding.ASCII.GetString _
                        (DESdecryptor.TransformFinalBlock(baBuffer, 0, baBuffer.Length))
    
                        Array.Clear(baBuffer, 0, baBuffer.Length)
                    Else
                        strReturnValue = ""
                    End If
    
                    Return strReturnValue
                Catch ex As Exception
                    'Me.Cursor() = Cursors.Default
                    Logging.WriteLogFile("FEHLER", ex.Message)
                    Logging.WriteLogFile("FEHLER", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("FEHLER", ex.StackTrace.ToString())
                    Console.WriteLine(ex.Message.ToString() & vbLf & vbLf & ex.StackTrace.ToString, MsgBoxStyle.Critical, "FEHLER ...")
                    Logging.WriteLogFile("MELDUNG", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("ENDE", "COR_DWG_Verwaltung beendet.")
                End Try
    
                Return strReturnValue
            End Function
    
    
            ' COR.CryptStrings.Crypt("abc")
            Public Shared Function Crypt(ByVal strSourceText As String) As String
                Dim strReturnValue As String = Nothing
                Try
    
                    TripleDESprovider.Key = MD5Hasher.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey))
                    TripleDESprovider.Mode = System.Security.Cryptography.CipherMode.ECB
                    Dim DESencryptor As System.Security.Cryptography.ICryptoTransform = TripleDESprovider.CreateEncryptor()
                    Dim baBuffer() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(strSourceText)
                    strReturnValue = Convert.ToBase64String _
                    (DESencryptor.TransformFinalBlock(baBuffer, 0, baBuffer.Length))
                    Array.Clear(baBuffer, 0, baBuffer.Length)
                    Return strReturnValue
                Catch ex As Exception
                    'Me.Cursor() = Cursors.Default
                    Logging.WriteLogFile("FEHLER", ex.Message)
                    Logging.WriteLogFile("FEHLER", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("FEHLER", ex.StackTrace.ToString())
                    Console.WriteLine(ex.Message.ToString & vbLf & vbLf & ex.StackTrace.ToString, MsgBoxStyle.Critical, "FEHLER ...")
                    Logging.WriteLogFile("MELDUNG", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("ENDE", "COR LDAP-Service beendet.")
                End Try
    
                Return strReturnValue
            End Function
    
    
            ' COR.CryptStrings.GenerateHash("abc")
            Public Shared Function GenerateHash(ByVal strSourceText As String) As String
    
                Try
                    Dim encUnicode As New System.Text.UnicodeEncoding
                    Dim ByteSourceText() As Byte = encUnicode.GetBytes(strSourceText)
                    Dim MD5_HashGenerator As New System.Security.Cryptography.MD5CryptoServiceProvider
                    Dim ByteHash() As Byte = MD5_HashGenerator.ComputeHash(ByteSourceText)
                    Return Convert.ToBase64String(ByteHash)
                Catch ex As Exception
                    'Me.Cursor() = Cursors.Default
                    Logging.WriteLogFile("FEHLER", ex.Message)
                    Logging.WriteLogFile("FEHLER", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("FEHLER", ex.StackTrace.ToString)
                    Console.WriteLine(ex.Message.ToString & vbLf & vbLf & ex.StackTrace.ToString, MsgBoxStyle.Critical, "FEHLER ...")
                    Logging.WriteLogFile("MELDUNG", "-----------------------------------------------------------------")
                    Logging.WriteLogFile("ENDE", "COR LDAP-Service beendet.")
                End Try
    
                Return Nothing
            End Function
    
    
        End Class 'CryptStrings
    
    
    End Namespace ' MyOrg
