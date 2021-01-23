        public class IPNController : Controller
        {
            private readonly ILogger _logger;
            private readonly IPaymentManager _paymentManager;
            private readonly IIdentityManager _identityManager;
    
            public IPNController(ILogger logger, IPaymentManager paymentManager, IIdentityManager identityManager)
            {
                _logger = logger;
                _paymentManager = paymentManager;
                _identityManager = identityManager;
            }
    
            [HttpPost]
            public HttpStatusCodeResult Receive(PayPalCheckoutInfo info)
            {
                //Fire and forget verification task
                Task.Run(() => VerifyTask(Request, info.Memo));
    
                //Reply back a 200 code
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
    
            private void VerifyTask(HttpRequestBase ipnRequest, string memo)
            {
                try
                {
                    var verificationRequest = (HttpWebRequest)WebRequest.Create(Application.PayPalIPNUrl);
    
                    //Set values for the verification request
                    verificationRequest.Method = "POST";
                    verificationRequest.ContentType = "application/x-www-form-urlencoded";
                    var param = Request.BinaryRead(ipnRequest.ContentLength);
                    var strRequest = Encoding.ASCII.GetString(param);
    
                    //Add cmd=_notify-validate to the payload
                    strRequest = "cmd=_notify-validate&" + strRequest;
                    verificationRequest.ContentLength = strRequest.Length;
    
                    //Attach payload to the verification request
                    var streamOut = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII);
                    streamOut.Write(strRequest);
                    streamOut.Close();
    
                    //Send the request to PayPal and get the response
                    var streamIn = new StreamReader(verificationRequest.GetResponse().GetResponseStream());
                    var verificationResponse = streamIn.ReadToEnd();
                    streamIn.Close();
    
                    var transactionIdentifier = memo.Split(':')[1].Trim();
    
                    //_logger.Info($"strRequest: {strRequest}");
                    //_logger.Info($"verificationResponse: {verificationResponse}");
    
                    // We receive 2 messages from PayPal.  Only complete this for one...
                    if (verificationResponse.Equals("VERIFIED"))
                    {
                        if (strRequest.Contains("payment_type=instant"))
                        {
                            _paymentManager.CompleteTransaction(transactionIdentifier);
                            _logger.Info($"IPNController.VerifyTask.  Payment marked as 'Paid'. transactionIdentifier={transactionIdentifier}");
                        }
                    }
                    else
                    {
                        _logger.Warn($"IPNController.VerifyTask.  A non-verified request was received.  transactionIdentifier={transactionIdentifier}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("IPNController.VerifyTask", ex);
                }
            }
        }
    
        public class PayPalCheckoutInfo
        {
            public string Memo { get; set; }
    
            //mc_gross=6.15
            //protection_eligibility=Ineligible
            //payer_id=ZJ93C8BT7HYE4
            //tax=0.00
            //payment_date=21:09:26 Jan 26, 2016 PST
            //payment_status=Completed
            //charset=windows-1252
            //first_name=Sandbox
            //mc_fee=0.48
            //notify_version=3.8
            //custom=
            //payer_status=verified
            //business=developer+application @trytn.com
            //quantity= 0
            //verify_sign = A8RQ0F8gkUzMctcqZ4r9aZzwD7JUA2ltLngw8Dny8kkzavsf9M8bRfZ3
            // payer_email = developer + merchant@trytn.com
            //memo= Trytn
            //txn_id = 52W35468KJ348570R
            //payment_type= instant
            //payer_business_name = Sandbox Merchant's Test Store
            //last_name= Merchant
            //receiver_email = developer + application@trytn.com
            //payment_fee= 0.48
            //receiver_id = VMLFKLT4VDZQL
            //txn_type = web_accept
            //item_name =
            //mc_currency = USD
            //item_number =
            //residence_country = US
            //test_ipn = 1
            //transaction_subject =
            //payment_gross = 6.15
            //ipn_track_id = 245bfe354148e
        }
