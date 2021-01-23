    public static string getOOM(string emailToCheck) //needs to be full email of user.
    {
                string EWSurl = String.Format("https://{0}/EWS/Exchange.asmx", ExchangePath);
                WebRequest webRequest = WebRequest.Create(EWSurl);
                HttpWebRequest httpwebRequest = (HttpWebRequest)webRequest;
                httpwebRequest.Method = "POST";
                httpwebRequest.ContentType = "text/xml; charset=utf-8";
                httpwebRequest.ProtocolVersion = HttpVersion.Version11;
                httpwebRequest.Credentials = new NetworkCredential("user", "password", "domain");//service Account
                httpwebRequest.Timeout = 60000;
                Stream requestStream = httpwebRequest.GetRequestStream();
                StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);
                StringBuilder getMailTipsSoapRequest = new StringBuilder("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
                getMailTipsSoapRequest.Append(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
                getMailTipsSoapRequest.Append("xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" ");
                getMailTipsSoapRequest.Append("xmlns:t=\"http://schemas.microsoft.com/exchange/services/2006/types\"><soap:Header>");
                getMailTipsSoapRequest.Append(" <t:RequestServerVersion Version=\"Exchange2010\"/></soap:Header><soap:Body>");
                getMailTipsSoapRequest.Append("<GetMailTips xmlns=\"http://schemas.microsoft.com/exchange/services/2006/messages\">");
                getMailTipsSoapRequest.Append("<SendingAs>");
                getMailTipsSoapRequest.Append("<t:EmailAddress>accessingemail@domain.com</t:EmailAddress>");
                getMailTipsSoapRequest.Append("<t:RoutingType>SMTP</t:RoutingType></SendingAs>");
                getMailTipsSoapRequest.Append("<Recipients><t:Mailbox>");
                getMailTipsSoapRequest.Append("<t:EmailAddress>" + emailToCheck + "</t:EmailAddress>");
                getMailTipsSoapRequest.Append("<t:RoutingType>SMTP</t:RoutingType></t:Mailbox></Recipients>");
                getMailTipsSoapRequest.Append(" <MailTipsRequested>OutOfOfficeMessage</MailTipsRequested></GetMailTips>");
                getMailTipsSoapRequest.Append("</soap:Body></soap:Envelope>");
                streamWriter.Write(getMailTipsSoapRequest.ToString());
                streamWriter.Close();
                HttpWebResponse webResponse = (HttpWebResponse)httpwebRequest.GetResponse();
                StreamReader streamreader = new StreamReader(webResponse.GetResponseStream());
                string response = streamreader.ReadToEnd();
                if (response.Contains("<t:Message/>"))
                    return null;
                int messageIndex = response.IndexOf("<t:Message>");
                response = response.Substring(messageIndex, response.IndexOf("</t:Message>") - messageIndex);
                return response;
    }
