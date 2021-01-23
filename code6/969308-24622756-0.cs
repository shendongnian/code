    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Drawing;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using System.Collections.Generic;
    using System.Web.Configuration;
    using System.Web.UI.HtmlControls;
    using System.Drawing.Imaging;
    using System.Drawing;
    
    
    public partial class paypal_IPNHandler : System.Web.UI.Page
    {
        string payerEmail;
        string paymentStatus;
        string receiverEmail;
        string amount;
        /// <summary>
        /// Process an incoming Instant Payment Notification (IPN)
        /// from PayPal, at conclusion of a received payment from a
        /// customer
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
    {
      // receive PayPal ipn data
    
      // extract ipn data into a string
      byte[] param = Request.BinaryRead(Request.ContentLength);
      string strRequest = Encoding.ASCII.GetString(param);
    
      // append PayPal verification code to end of string
      strRequest = "cmd=_notify-validate&" + strRequest;
        
      // create an HttpRequest channel to perform handshake with PayPal
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://www.paypal.com/cgi-bin/webscr");
      req.Method = "POST";
      req.ContentType = "application/x-www-form-urlencoded";
      req.ContentLength = strRequest.Length;
    
      // send data back to PayPal to request verification
      StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
      streamOut.Write(strRequest);
      streamOut.Close();
    
      // receive response from PayPal
      StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
      string strResponse = streamIn.ReadToEnd();
      streamIn.Close();
    
      // if PayPal response is successful / verified
      if (strResponse.Equals("VERIFIED"))
      {
        // paypal has verified the data, it is safe for us to perform processing now
    
        // extract the form fields expected: buyer and seller email, payment status, amount
        payerEmail = Request.Form["payer_email"];
        paymentStatus = Request.Form["payment_status"];
        receiverEmail = Request.Form["receiver_email"];
        amount = Request.Form["mc_gross"];
    
       
      }
        // else
        else
        {
          // payment not complete yet, may be undergoing additional verification or processing
    
          // do nothing - wait for paypal to send another IPN when payment is complete
        }
      String insertConnString = System.Configuration.ConfigurationManager.ConnectionStrings["BeachConnectionString"].ConnectionString;
      using (SqlConnection insertcon = new SqlConnection(insertConnString))
      using (SqlCommand cmdinsert = insertcon.CreateCommand())
      {
          string insertprofile = "INSERT INTO Test (Status, Text) VALUES (@Status, @Text)";
          cmdinsert.CommandText = insertprofile;
          cmdinsert.Parameters.Add("@Status", SqlDbType.VarChar).Value = strResponse.ToString();
          cmdinsert.Parameters.Add("@Text", SqlDbType.VarChar).Value = strRequest.ToString();
          cmdinsert.Connection.Open();
          cmdinsert.ExecuteNonQuery();
      }
      }       
    }
