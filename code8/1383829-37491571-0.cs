    public partial class Form1 : Form 
    {
        // Declare CspParmeters and RsaCryptoServiceProvider
        // objects with global scope of your Form class.
        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider rsa;
        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string EncrFolder = @"c:\Encrypt\";
        const string DecrFolder = @"c:\Decrypt\";
        const string SrcFolder = @"c:\docs\";
        // Public key file
        const string PubKeyFile = @"c:\encrypt\rsaPublicKey.txt";
        // Key container name for
        // private/public key value pair.
        const string keyName = "Key01";
        public Form1()
        {
            InitializeComponent();
            // NOT HERE in the constructor, this scope will not work 
        }
    }
