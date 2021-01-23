    @using System;
    @using System.Collections.Generic;
    @using Braintree;
    @using System.Diagnostics;
    @{
        Layout = "~/template";
        //Initialise Braintree Server SDK
        BraintreeGateway gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            PublicKey = "xxx",
            PrivateKey = "xxx",
            MerchantId = "xxx"
        };
    }
    @gateway.WebhookNotification.Verify(Request.QueryString["bt_challenge"]);
