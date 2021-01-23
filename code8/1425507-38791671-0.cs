        public long Post_RedeemVoucher(Response _response, string token)
        {
            string client_URL_voucher_redeem = "https://myurl";
            string body = "mypostBody";
            Task<Response> content = Post(null, client_URL_voucher_redeem, token, body);
            if (content.Exception == null)
            {
                return 200;
            }
            else
                return -1;
        }
