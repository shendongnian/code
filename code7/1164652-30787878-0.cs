    Imports System.IO
    Imports System.Security.Cryptography
    Imports System.Text
    
    Namespace Cypher
    
        Public NotInheritable Class SagePayAESCBCPKCS5
    
            ' Singleton pattern used here with ensured thread safety
            Protected Shared ReadOnly _instance As New SagePayAESCBCPKCS5()
            Public Shared ReadOnly Property Instance() As SagePayAESCBCPKCS5
                Get
                    Return _instance
                End Get
            End Property
    
    
            Public Sub New()
            End Sub
    
            Public Function DecryptText(encryptedString As String, encryptionKey As String) As String
                Using myRijndael As RijndaelManaged = New RijndaelManaged()
                    myRijndael.BlockSize = 128
                    myRijndael.KeySize = 128
    
                    myRijndael.Key = UTF8Encoding.UTF8.GetBytes(encryptionKey)
                    myRijndael.IV = UTF8Encoding.UTF8.GetBytes(encryptionKey)
    
                    myRijndael.Mode = CipherMode.CBC
                    myRijndael.Padding = PaddingMode.None
    
                    Dim encByte As [Byte]() = HexStringToByte(encryptedString)
    
                    'Create a decrytor to perform the stream transform.
                    Dim decryptor As ICryptoTransform = myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV)
                    Dim plaintext As String = ""
                    ' Create the streams used for decryption. 
                    Using msDecrypt As New MemoryStream(encByte)
                        Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                            Using srDecrypt As New StreamReader(csDecrypt)
    
                                ' Read the decrypted bytes from the decrypting stream 
                                ' and place them in a string.
                                plaintext = srDecrypt.ReadToEnd()
                                srDecrypt.Close()
                                csDecrypt.Close()
                                msDecrypt.Close()
                            End Using
                        End Using
    
                    End Using
                    Return plaintext
    
                End Using
            End Function
    
    
            Public Function EncryptText(plainText As String, encryptionKey As String) As String
                Using myRijndael As RijndaelManaged = New RijndaelManaged()
                    myRijndael.BlockSize = 128
                    myRijndael.KeySize = 128
    
                    myRijndael.Key = UTF8Encoding.UTF8.GetBytes(encryptionKey)
                    myRijndael.IV = UTF8Encoding.UTF8.GetBytes(encryptionKey)
    
                    myRijndael.Mode = CipherMode.CBC
                    myRijndael.Padding = PaddingMode.PKCS7
    
                    Dim encrypted As Byte()
                    ' Create a decrytor to perform the stream transform.
                    Dim encryptor As ICryptoTransform = myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV)
    
                    ' Create the streams used for encryption. 
                    Using msEncrypt As New MemoryStream()
                        Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                            Using swEncrypt As New StreamWriter(csEncrypt)
                                'Write all data to the stream.
                                swEncrypt.Write(plainText)
                            End Using
                            encrypted = msEncrypt.ToArray()
                        End Using
                    End Using
                    'Dim encrypted As Byte() = EncryptStringToBytes(plainText, myRijndael.Key, myRijndael.IV)
                    'Dim encString As String = Convert.ToBase64String(encrypted)
                    Dim encString As String = ByteArrayToHexString(encrypted)
                    Return encString
                End Using
            End Function
    
            Protected Shared Function HexStringToByte(hexString As String) As Byte()
                Try
                    Dim bytesCount As Integer = (hexString.Length) \ 2
                    Dim bytes As Byte() = New Byte(bytesCount - 1) {}
                    For x As Integer = 0 To bytesCount - 1
                        bytes(x) = Convert.ToByte(hexString.Substring(x * 2, 2), 16)
                    Next
                    Return bytes
                Catch
                    Throw
                End Try
            End Function
    
            Public Shared Function ByteArrayToHexString(ba As Byte()) As String
                Dim hex As New StringBuilder(ba.Length * 2)
                For Each b As Byte In ba
                    hex.AppendFormat("{0:x2}", b)
                Next
                Return hex.ToString()
            End Function
        End Class
    End Namespace
