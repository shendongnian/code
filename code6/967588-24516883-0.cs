    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Net;
    using BLL;
    
    public partial class notifypaypal : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
    
           
            //Post back to either sandbox or live
           // string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";//For localhost
            string strLive = "https://www.paypal.com/cgi-bin/webscr";//For live server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);
    
            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            string ipnPost = strRequest;
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;
    
            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;
    
            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();
    
            // logging ipn messages... be sure that you give write permission to process executing this code
            string logPathDir = ResolveUrl("Messages");
            string logPath = string.Format("{0}\\{1}.txt",Server.MapPath(logPathDir), DateTime.Now.Ticks);
            File.WriteAllText(logPath, ipnPost);
           
    
            if (strResponse == "VERIFIED")
            {
    
                #region [Update Order Status]
                string txn_id = HttpContext.Current.Request["txn_id"]; //txn_id=	Unique transaction number.
                string payment_status = HttpContext.Current.Request["payment_status"];   //payment_status=Payment state(Completed,Pending,Failed,Denied,Refunded)
                string pending_reason = HttpContext.Current.Request["pending_reason"];   //pending_reason=Reason of payment delay(echeck,multi_currency,intl,verify,...)
                string item_number = HttpContext.Current.Request["item_number"];  //item_number=order number
    
               
                if (HttpContext.Current.Request["payment_status"].ToString() == "Completed")
                {
                    try
                    {
    //update in database that particular "item_number"(Order number) is successfully  Completed
                      
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (HttpContext.Current.Request["payment_status"].ToString() == "Pending")
                    {
                        try
                        {
                            //update in database that particular "item_number"(Order number) is Pending
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                       
                    }
                }
                #endregion
    
    
            }
            else if (strResponse == "INVALID")
            {
    
            }
            else
            {
    
    
            }
        }     
             
    }
