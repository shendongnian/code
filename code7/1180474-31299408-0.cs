    ------------------------------------------------------------
    // Default.aspx
    ------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace SSOClient
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                SSOLogin ssoLogin = new SSOLogin();
                
                ssoLogin.SAML = SSOLogin.SAML_TEMPLATE;
                ssoLogin.ServiceProviderUrl = "";
                ssoLogin.Certificate = new Certificate() { Path = Server.MapPath("/Certificates")  + "/" + "SSOClientCert.pfx", Password = "abcd1234" };
                ssoLogin.Issuer = "SSOClientCert";
                ssoLogin.NameID = "guest";
                ssoLogin.Logout = "http://www.google.com";
                ssoLogin.Controller = "Home";
                ssoLogin.TokenMethod = "SystemID";
                ssoLogin.CustomTokenForVerification = "46";
                ssoLogin.AutoSubmitMessage = false;
    
                ssoLogin.Post(Response);
    
                ssoLogin = null;
    
                /*SSOLogout ssoLogout = new SSOLogout();
    
                ssoLogout.SAML = SSOLogout.SAML_TEMPLATE;
                ssoLogout.ServiceProviderUrl = "";
                ssoLogout.Certificate = new Certificate() { Path = Server.MapPath("/Certificates") + "/" + "SSOClientCert.pfx", Password = "abcd1234" };
                ssoLogout.Issuer = "SSOClientCert";
                ssoLogout.NameID = "guest";
                ssoLogout.AutoSubmitMessage = false;
    
                ssoLogout.Post(Response);
    
                ssoLogout = null;*/
            }
        }
    }
    
    ------------------------------------------------------------
    // Classes
    ------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Web;
    using System.Xml;
    
    namespace SSOClient
    {
    #region Certificate Class
        public class Certificate
        {
            private string _Path = "";
            private string _Password = "";
    
            public string Path
            {
                get { return this._Path; }
                set { this._Path = value; }
            }
    
            public string Password
            {
                get { return this._Password; }
                set { this._Password = value; }
            }
        }
    #endregion
    
    #region SSOBase Class
        public abstract class SSOBase
        {
            public const string HIDDEN_INPUT_TEMPLATE = @"<input type=""hidden"" name=""{0}"" value=""{1}"" />";
    
            private Certificate _Certificate = null;
            private string _ServiceProviderUrl = "";
            private string _ConsumerServicePath = "";
            private string _RelayState = "";
            private string _MessageID = "";
            private string _IssueInstant = "";
            private string _Issuer = "";
            private string _NameID = "";
            private string _SigAlg = "";
            private string _Signature = "";
            private string _SAML = "";
            private string _SAMLSigned = "";
    
            private bool _AutoSubmitMessage = false;
    
            public Certificate Certificate
            {
                get { return this._Certificate; }
                set { this._Certificate = value; }
            }
    
            public string ServiceProviderUrl
            {
                get { return this._ServiceProviderUrl; }
                set { this._ServiceProviderUrl = value; }
            }
    
            public string ConsumerServicePath
            {
                get { return this._ConsumerServicePath; }
                set { this._ConsumerServicePath = value; }
            }
    
            public string RelayState
            {
                get { return this._RelayState; }
                set { this._RelayState = value; }
            }
    
            public string MessageID
            {
                get { return this._MessageID; }
                set { this._MessageID = value; }
            }
    
            public string IssueInstant
            {
                get { return this._IssueInstant; }
                set { this._IssueInstant = value; }
            }
    
            public string Issuer
            {
                get { return this._Issuer; }
                set { this._Issuer = value; }
            }
    
            public string NameID
            {
                get { return this._NameID; }
                set { this._NameID = value; }
            }
    
            public string SigAlg
            {
                get { return this._SigAlg; }
                set { this._SigAlg = value; }
            }
    
            public string Signature
            {
                get { return this._Signature; }
                set { this._Signature = value; }
            }
    
            public string SAML
            {
                get { return this._SAML; }
                set { this._SAML = value; }
            }
    
            public string SAMLSigned
            {
                get { return this._SAMLSigned; }
                set { this._SAMLSigned = value; }
            }
    
            public bool AutoSubmitMessage
            {
                get { return this._AutoSubmitMessage; }
                set { this._AutoSubmitMessage = value; }
            }
    
            public SSOBase()
            {
                this._Certificate = null;
                this._ServiceProviderUrl = "";
                this._ConsumerServicePath = "";
                this._RelayState = System.Guid.NewGuid().ToString();
                this._MessageID = String.Format("_{0}", System.Guid.NewGuid().ToString().Replace("-", "").ToUpper());
                this._IssueInstant = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                this._Issuer = "";
                this._NameID = "";
                this._SigAlg = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                this._Signature = "";
                this._SAML = "";
                this._SAMLSigned = "";
    
                this._AutoSubmitMessage = false;
            }
    
            public XmlDocument Sign(X509Certificate2 x509Certificate, XmlDocument xmlDocument, string referenceId)
            {
                SignedXml signedXml = new SignedXml(xmlDocument);
    
                X509Certificate2Collection x509Certificate2Collection;
                try
                {
                    x509Certificate2Collection = new X509Certificate2Collection();
                    x509Certificate2Collection.Add(x509Certificate);
                }
                catch (Exception exception)
                {
                    throw;
                }
    
                KeyInfo keyInfo;
                try
                {
                    keyInfo = new KeyInfo();
    
                    KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data();
    
                    X509Certificate2Enumerator enumerator = x509Certificate2Collection.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        keyInfoX509Data.AddCertificate(enumerator.Current);
                    }
    
                    keyInfo.AddClause(keyInfoX509Data);
                }
                catch (Exception exception)
                {
                    throw;
                }
    
                XmlElement xmlElement = null;
    
                try
                {
                    signedXml.SigningKey = x509Certificate.PrivateKey;
                    signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/2001/10/xml-exc-c14n#";
    
                    Reference reference = new Reference()
                    {
                        Uri = string.Concat("#", referenceId)
                    };
    
                    reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
    
                    XmlDsigExcC14NTransform xmlDsigExcC14NTransform = new XmlDsigExcC14NTransform();
    
                    if (!string.IsNullOrEmpty("#default samlp saml ds xs xsi"))
                    {
                        xmlDsigExcC14NTransform.InclusiveNamespacesPrefixList = "#default samlp saml ds xs xsi";
                    }
    
                    reference.AddTransform(xmlDsigExcC14NTransform);
    
                    signedXml.AddReference(reference);
                    signedXml.KeyInfo = keyInfo;
    
                    signedXml.ComputeSignature();
    
                    this._Signature = Convert.ToBase64String(signedXml.SignatureValue, Base64FormattingOptions.None);
    
                    xmlElement = signedXml.GetXml();
    
                    XmlNode root = xmlDocument.DocumentElement;
    
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
    
                    nsmgr.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
    
                    XmlNode issuer = xmlDocument.SelectSingleNode("//saml:Issuer", nsmgr);
    
                    root.InsertAfter(xmlElement, issuer);
    
                    return xmlDocument;
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
        }
    #endregion
    
    #region SSOLogin Class
        public class SSOLogin : SSOBase
        {
            public const string SAML_TEMPLATE = @"<samlp:Response ID=""@ResponseID"" Version=""2.0"" IssueInstant=""@IssueInstant"" xmlns:samlp=""urn:oasis:names:tc:SAML:2.0:protocol""><saml:Issuer xmlns:saml=""urn:oasis:names:tc:SAML:2.0:assertion"">@Issuer</saml:Issuer><samlp:Status><samlp:StatusCode Value=""urn:oasis:names:tc:SAML:2.0:status:Success"" /></samlp:Status><saml:Assertion Version=""2.0"" ID=""@AssertionID"" IssueInstant=""@IssueInstant"" xmlns:saml=""urn:oasis:names:tc:SAML:2.0:assertion""><saml:Subject><saml:NameID>@NameID</saml:NameID></saml:Subject><saml:AuthnStatement AuthnInstant=""@AuthnInstant"" /><saml:AttributeStatement><saml:Attribute Name=""Logout"" NameFormat=""urn:oasis:names:tc:SAML:2.0:attrname-format:basic""><saml:AttributeValue>@Logout</saml:AttributeValue></saml:Attribute><saml:Attribute Name=""Controller"" NameFormat=""urn:oasis:names:tc:SAML:2.0:attrname-format:basic""><saml:AttributeValue>@Controller</saml:AttributeValue></saml:Attribute><saml:Attribute Name=""TokenMethod"" NameFormat=""urn:oasis:names:tc:SAML:2.0:attrname-format:basic""><saml:AttributeValue>@TokenMethod</saml:AttributeValue></saml:Attribute><saml:Attribute Name=""CustomTokenForVerification"" NameFormat=""urn:oasis:names:tc:SAML:2.0:attrname-format:basic""><saml:AttributeValue>@CustomTokenForVerification</saml:AttributeValue></saml:Attribute></saml:AttributeStatement></saml:Assertion></samlp:Response>";
    
            private string _AssertionID = "";
            private string _AuthnInstant = "";
            private string _Logout = "";
            private string _Controller = "";
            private string _TokenMethod = "";
            private string _CustomTokenForVerification = "";
    
            public string AssertionID
            {
                get { return this._AssertionID; }
                set { this._AssertionID = value; }
            }
    
            public string AuthnInstant
            {
                get { return this._AuthnInstant; }
                set { this._AuthnInstant = value; }
            }
    
            public string Logout
            {
                get { return this._Logout; }
                set { this._Logout = value; }
            }
    
            public string Controller
            {
                get { return this._Controller; }
                set { this._Controller = value; }
            }
    
            public string TokenMethod
            {
                get { return this._TokenMethod; }
                set { this._TokenMethod = value; }
            }
    
            public string CustomTokenForVerification
            {
                get { return this._CustomTokenForVerification; }
                set { this._CustomTokenForVerification = value; }
            }
    
            public SSOLogin()
            {
                this._AssertionID = String.Format("_{0}", System.Guid.NewGuid().ToString().Replace("-", "").ToUpper());
                this._AuthnInstant = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                this._Logout = "";
                this._Controller = "";
                this._TokenMethod = "";
                this._CustomTokenForVerification = "";
            }
    
            public void Post(HttpResponse response)
            {
                try
                {
                    if (base.SAML == "")
                    {
                        base.SAML = SAML_TEMPLATE;
                    }
    
                    base.SAML = base.SAML.Replace("@ResponseID", base.MessageID);
                    base.SAML = base.SAML.Replace("@IssueInstant", base.IssueInstant);
                    base.SAML = base.SAML.Replace("@Issuer", base.Issuer);
                    base.SAML = base.SAML.Replace("@AssertionID", this._AssertionID);
                    base.SAML = base.SAML.Replace("@AuthnInstant", this._AuthnInstant);
                    base.SAML = base.SAML.Replace("@NameID", base.NameID);
                    base.SAML = base.SAML.Replace("@Logout", this._Logout);
                    base.SAML = base.SAML.Replace("@Controller", this._Controller);
                    base.SAML = base.SAML.Replace("@TokenMethod", this._TokenMethod);
                    base.SAML = base.SAML.Replace("@CustomTokenForVerification", this._CustomTokenForVerification);
    
                    XmlDocument xmlDocument = new XmlDocument();
    
                    xmlDocument.LoadXml(base.SAML);
    
                    XmlDocument xmlDocumentSigned = this.Sign(new X509Certificate2(base.Certificate.Path, base.Certificate.Password), xmlDocument, base.MessageID);
    
                    byte[] signedByteArray = Encoding.UTF8.GetBytes(xmlDocumentSigned.InnerXml);
    
                    base.SAMLSigned = Convert.ToBase64String(signedByteArray, Base64FormattingOptions.None);
    
                    IDictionary<string, string> hiddenInputDic = new Dictionary<string, string>();
    
                    hiddenInputDic.Add("SAMLResponse", base.SAMLSigned);
                    hiddenInputDic.Add("RelayState", base.RelayState);
    
                    StringBuilder hiddenInputs = new StringBuilder();
    
                    foreach (string hiddenInputName in hiddenInputDic.Keys)
                    {
                        string hiddenFieldValue = hiddenInputDic[hiddenInputName];
    
                        hiddenInputs.AppendFormat(SSOBase.HIDDEN_INPUT_TEMPLATE + Environment.NewLine,
                            hiddenInputName,
                            HttpUtility.HtmlEncode(hiddenFieldValue));
                    }
    
                    string samlForm = String.Format(@"
    <form id=""samlForm"" action=""{0}"" method=""post"">
        {1}
        <input type=""submit"" name=""btnLogin"" value=""Login"" />
    </form>",
                            String.Format("{0}{1}", this.ServiceProviderUrl, base.ConsumerServicePath),
                            hiddenInputs.ToString());
    
                    string pageTemplate = @"
    <!DOCTYPE html>
    <html xmlns=""http://www.w3.org/1999/xhtml"">
        <body{0}>
            <h3>SAML SSO - Login Example</h3>
            <p>Please click the Login button to Login.</p>
            <div>
                {1}
            </div>
            <hr>
            <h3>SAML Form</h3>
            <div>
                <textarea cols=""100"" rows=""50"">
                    {2} 
                </textarea>
            </div>
        </body>
    </html>";
    
                    HttpContext httpContext = HttpContext.Current;
    
                    StringBuilder html = new StringBuilder();
    
                    html.AppendFormat(pageTemplate,
                        base.AutoSubmitMessage ? @" onload=""document.getElementById('samlForm').submit();""" : "",
                        samlForm,
                        httpContext.Server.HtmlEncode(samlForm));
    
                    StreamWriter outputStream = new StreamWriter(response.OutputStream);
                    outputStream.Write(html.ToString());
                    outputStream.Flush();
                }
                catch (Exception exception)
                {
                    response.Write(exception.ToString());
                }
            }
        }
    #endregion
    
    #region SSOLogout Class
        public class SSOLogout : SSOBase
        {
            public const string SAML_TEMPLATE = @"<saml:LogoutRequest ID=""@RequestID"" Version=""2.0"" IssueInstant=""@IssueInstant"" xmlns:saml=""urn:oasis:names:tc:SAML:2.0:protocol""><saml:Issuer xmlns:saml=""urn:oasis:names:tc:SAML:2.0:assertion"">@Issuer</saml:Issuer><saml:NameID xmlns:saml=""urn:oasis:names:tc:SAML:2.0:assertion"">@NameID</saml:NameID></saml:LogoutRequest>";
    
            public SSOLogout()
            {
            }
    
            public void Post(HttpResponse response)
            {
                try
                {
                    if (base.SAML == "")
                    {
                        base.SAML = SAML_TEMPLATE;
                    }
    
                    base.SAML = base.SAML.Replace("@RequestID", base.MessageID);
                    base.SAML = base.SAML.Replace("@IssueInstant", base.IssueInstant);
                    base.SAML = base.SAML.Replace("@Issuer", base.Issuer);
                    base.SAML = base.SAML.Replace("@NameID", base.NameID);
    
                    XmlDocument xmlDocument = new XmlDocument();
    
                    xmlDocument.LoadXml(base.SAML);
    
                    XmlDocument xmlDocumentSigned = this.Sign(new X509Certificate2(base.Certificate.Path, base.Certificate.Password), xmlDocument, base.MessageID);
    
                    byte[] signedByteArray = Encoding.UTF8.GetBytes(xmlDocumentSigned.InnerXml);
    
                    base.SAMLSigned = Convert.ToBase64String(signedByteArray, Base64FormattingOptions.None);
    
                    IDictionary<string, string> hiddenInputDic = new Dictionary<string, string>();
    
                    hiddenInputDic.Add("SAMLRequest", base.SAMLSigned);
                    hiddenInputDic.Add("RelayState", base.RelayState);
                    hiddenInputDic.Add("SigAlg", base.SigAlg);
                    hiddenInputDic.Add("Signature", base.Signature);
    
                    StringBuilder hiddenInputs = new StringBuilder();
    
                    foreach (string hiddenInputName in hiddenInputDic.Keys)
                    {
                        string hiddenFieldValue = hiddenInputDic[hiddenInputName];
    
                        hiddenInputs.AppendFormat(SSOBase.HIDDEN_INPUT_TEMPLATE + Environment.NewLine,
                            hiddenInputName,
                            HttpUtility.HtmlEncode(hiddenFieldValue));
                    }
    
                    string samlForm = String.Format(@"
    <form id=""samlForm"" action=""{0}"" method=""post"">
        {1}
        <input type=""submit"" name=""btnLogout"" value=""Logout"" />
    </form>", 
                        String.Format("{0}{1}", this.ServiceProviderUrl, base.ConsumerServicePath),
                        hiddenInputs.ToString());
    
                    string pageTemplate = @"
    <!DOCTYPE html>
    <html xmlns=""http://www.w3.org/1999/xhtml"">
        <body{0}>
            <h3>SAML SSO - Logout Example</h3>
            <p>Please click the Logout button to Logout.</p>
            <div>
                {1}
            </div>
            <hr>
            <h3>SAML Form</h3>
            <div>
                <textarea cols=""100"" rows=""50"">
                    {2} 
                </textarea>
            </div>
        </body>
    </html>";
    
                    HttpContext httpContext = HttpContext.Current;
    
                    StringBuilder html = new StringBuilder();
    
                    html.AppendFormat(pageTemplate,
                        base.AutoSubmitMessage ? @" onload=""document.getElementById('samlForm').submit();""" : "",
                        samlForm,
                        httpContext.Server.HtmlEncode(samlForm));
    
                    StreamWriter outputStream = new StreamWriter(response.OutputStream);
                    outputStream.Write(html.ToString());
                    outputStream.Flush();
                }
                catch (Exception exception)
                {
                    response.Write(exception.ToString());
                }
            }
        }
    #endregion
    }
