        [HttpPost]
        [Route("api/webhooks/accept")]
        public async Task<IHttpActionResult> accept(bt bt_lot)
        {
            var gateway = config.GetGateway();
            WebhookNotification webhookNotification = gateway.WebhookNotification.Parse(
                bt_lot.bt_signature,
                bt_lot.bt_payload
                );
            if (webhookNotification.Kind == WebhookKind.SUBSCRIPTION_CANCELED)
            {
                // take your action here...
            }
