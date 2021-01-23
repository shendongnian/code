    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security;
    using System.Web;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace CryptoGraphicHash
    {
        public partial class Form1 : Form
        {
            static uint CRYPT_NEWKEYSET = 0x8;
    
            static uint CRYPT_MACHINE_KEYSET = 0x20;
            
            static uint ALG_CLASS_HASH = 32768;
            // Algorithm types
            static uint ALG_TYPE_ANY = 0;
    
            static uint PROV_RSA_FULL = 1;
            static uint ALG_SID_SHA = 4;
    
            static string MS_DEF_PROV = "Microsoft Base Cryptographic Provider v1.0";
            static uint CALG_SHA = ALG_CLASS_HASH + ALG_TYPE_ANY + ALG_SID_SHA;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var test = GenerateHash(textBox1.Text);
                textBox2.Text = test;
            }
    
            private void HandleWin32Error()
            {
                var error = Marshal.GetLastWin32Error();
                Win32Exception ex = new Win32Exception(error);
                MessageBox.Show("Last Win32 error code: " + error);
                MessageBox.Show("Last Win32 error msg: " + ex.Message);
            }
    
            private string GenerateHash(string plaintext)
            {            
                string sContainer = string.Empty;
                string sProvider = MS_DEF_PROV;
                
                IntPtr hProv = new IntPtr();
                IntPtr hKey = new IntPtr(0);
                IntPtr phHash = new IntPtr();
                            
                try
                {
                    bool res = Crypt32.CryptAcquireContext(out hProv, sContainer, sProvider, PROV_RSA_FULL, 0);
                    if (!res)
                    {
                        MessageBox.Show("CryptAcquireContext is false for first time so will try again with CRYPT_NEWKEYSET.");
                        HandleWin32Error();
                        bool res1 = Crypt32.CryptAcquireContext(out hProv, sContainer, sProvider, PROV_RSA_FULL, CRYPT_MACHINE_KEYSET + CRYPT_NEWKEYSET);
                        if (!res1)
                        {
                            MessageBox.Show("CryptAcquireContext is false for second time so exiting the hash.");
                            HandleWin32Error();
                            return string.Empty;
                        }
                    }
                    MessageBox.Show("hProv handle value is: " + hProv.ToString());
                    //Once we have received the context, next we create hash object                
                    bool hashCreateResponse = Crypt32.CryptCreateHash(hProv, CALG_SHA, hKey, 0, ref phHash);
                    if (!hashCreateResponse)
                    {
                        MessageBox.Show("CryptCreateHash is false so exiting with last win32 error: " + Marshal.GetLastWin32Error());
                        return string.Empty;
                    }
                    //Hash the data
                    byte[] pbData = Encoding.ASCII.GetBytes(plaintext);
                    bool hashDataResponse = Crypt32.CryptHashData(phHash, pbData, (uint)plaintext.Length, 0);
                    if (!hashDataResponse)
                    {
                        MessageBox.Show("CryptHashData is false so exiting.");
                        return string.Empty;
                    }
                    uint paramLen = 0;
                    byte[] paramValue = new byte[0];
    
                    bool getHashParamResponse = Crypt32.CryptGetHashParam(phHash, 0x0002, paramValue, ref paramLen, 0);
    
                    if (234 == Marshal.GetLastWin32Error())
                    {
                        paramValue = new byte[paramLen];
                        bool getHashParamResponse1 = Crypt32.CryptGetHashParam(phHash, 0x0002, paramValue, ref paramLen, 0);
                    }
    
                    //destroy the key
                    Crypt32.CryptDestroyKey(hKey);
    
                    //Destroy the hash object
                    Crypt32.CryptDestroyHash(phHash);
                    
                    //Release provider handle
                    Crypt32.CryptReleaseContext(hProv, 0);
                    var sb = new StringBuilder();
                    foreach(var item in paramValue)
                    {
                        sb.Append(Microsoft.VisualBasic.Strings.Chr(item));
                    }
                    return sb.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.InnerException.StackTrace);
                    throw ex;
                }
            }
        }
    
    
        public class Crypt32
        {
            public enum HashParameters
            {
                HP_ALGID = 0x0001,   // Hash algorithm
                HP_HASHVAL = 0x2, // Hash value
                HP_HASHSIZE = 0x0004 // Hash value size
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CryptAcquireContext(
    out IntPtr phProv,
    string pszContainer,
    string pszProvider,
    uint dwProvType,
    uint dwFlags);
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool CryptCreateHash(IntPtr hProv, uint algId, IntPtr hKey, uint dwFlags, ref IntPtr phHash);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool CryptDestroyHash(IntPtr hHash);        
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool CryptDestroyKey(IntPtr phKey);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool CryptHashData(IntPtr hHash, byte[] pbData, uint dataLen, uint flags);
    
            [DllImport("Advapi32.dll", EntryPoint = "CryptReleaseContext", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool CryptReleaseContext(IntPtr hProv,Int32 dwFlags);
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool CryptGetHashParam(IntPtr hHash,
            uint dwParam,
            Byte[] pbData,
            ref uint pdwDataLen,
            uint dwFlags);
            //public static extern bool CryptGetHashParam(IntPtr hHash, uint dwParam, [Out] byte[] pbData, [In, Out] uint pdwDataLen, uint dwFlags);
        }   
    }
