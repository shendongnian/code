    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("Url of the site");
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    response.Close();
    var cerificateFromClient = request.ServicePoint.Certificate;   
    X509Certificate2 certificateFromServer = new X509Certificate2("path to certificate", "Passwod");
    var serialFromClient = cerificateFromClient.GetSerialNumberString();
    var serialFromServer = certificateFromServer.GetSerialNumberString();  
    //Checking if both the serial numbers are same
    bool isSame = string.Equals(serialFromClient, serialFromClient);
