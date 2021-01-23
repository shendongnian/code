    namespace SomeNameSpace
    {
    public enum CryptType { ENCRYPT, DECRYPT }
    public enum CryptTechnique { AES, RC2, RIJ, DES, TDES }
    public class Cryptography
    {
        public object Crypt(CryptType EncryptOrDecrypt, CryptTechnique CryptographicTechnique, object Input, string Key)
        {
            try
            {
                SymmetricAlgorithm SymAlgo; //This class is parent of all classes in CryptTechnique enums
                switch (CryptographicTechnique)
                {
                    case CryptTechnique.AES:
                        SymAlgo = new AesManaged();
                        break;
                    case CryptTechnique.RC2:
                        SymAlgo = new RC2CryptoServiceProvider();
                        break;
                    case CryptTechnique.RIJ:
                        SymAlgo = new RijndaelManaged();
                        break;
                    case CryptTechnique.DES:
                        SymAlgo = new DESCryptoServiceProvider();
                        break;
                    case CryptTechnique.TDES:
                        SymAlgo = new TripleDESCryptoServiceProvider();
                        break;
                    default:
                        return false;
                }
                SymAlgo.Key = UTF8Encoding.UTF8.GetBytes(Key);
                SymAlgo.Padding = PaddingMode.PKCS7;
                SymAlgo.Mode = CipherMode.ECB;
                ICryptoTransform ICT = null;
                byte[] resultArray;
                if(EncryptOrDecrypt == CryptType.ENCRYPT)
                {
                    ICT = SymAlgo.CreateEncryptor();
                }
                else if(EncryptOrDecrypt == CryptType.DECRYPT)
                {
                    ICT = SymAlgo.CreateDecryptor();
                }
                if (Input is string)
                {
                    byte[] inputArray = UTF8Encoding.UTF8.GetBytes(Input as string);
                    resultArray = ICT.TransformFinalBlock(inputArray, 0, inputArray.Length);
                    SymAlgo.Clear();
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
                else if (Input is byte[])
                {
                    resultArray = ICT.TransformFinalBlock(Input as byte[], 0, (Input as byte[]).Length);
                    SymAlgo.Clear();
                    return resultArray;
                }
                return false;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
    }
