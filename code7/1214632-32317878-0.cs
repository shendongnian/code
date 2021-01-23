    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Security.Cryptography.X509Certificates;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                string input =
                    "<?xml version=\"1.0\"?>" +
                    "<root></root>";
                doc.LoadXml(input);
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCollection = store.Certificates;
                SignXml(doc, certCollection[0]);
            }
           
            public static void SignXml(XmlDocument xmlDoc, X509Certificate2 uidCert)
            {
                RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)uidCert.PrivateKey;
                // Check arguments. 
                if (xmlDoc == null)
                    throw new ArgumentException("xmlDoc");
                if (rsaKey == null)
                    throw new ArgumentException("Key");
                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(xmlDoc);
                // Add the key to the SignedXml document.
                signedXml.SigningKey = rsaKey;
                // Create a reference to be signed.
                Reference reference = new Reference();
                reference.Uri = "";
                // Add an enveloped transformation to the reference.
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);
                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);
                // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
                KeyInfo keyInfo = new KeyInfo();
                KeyInfoX509Data clause = new KeyInfoX509Data();
                clause.AddSubjectName(uidCert.Subject);
                clause.AddCertificate(uidCert);
                keyInfo.AddClause(clause);
                signedXml.KeyInfo = keyInfo;
                // Compute the signature.
                signedXml.ComputeSignature();
                // Get the XML representation of the signature and save 
                // it to an XmlElement object.
                XmlElement xmlDigitalSignature = signedXml.GetXml();
                System.Console.WriteLine(signedXml.GetXml().InnerXml);
                // Append the element to the XML docu0ment.
                XmlElement root = (XmlElement)xmlDoc.GetElementsByTagName("root")[0];
                XmlElement myElement = xmlDoc.CreateElement("myelement");
                root.AppendChild(myElement);
                myElement.AppendChild(xmlDigitalSignature);
            }
        }
    }
    ​
