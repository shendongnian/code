     string message = "";// "code=7af66fd73427a1634cee3103297230b8&rlr=9DFD5EA9-7747-4142-97D9-2D44BBA442F1&shop=appswiz.myshopify.com&state=fa992b8f-762e-4813-b707-6044e71ad3b5&timestamp=1448856806";
            message = "code=xxxxxxxx";
            message += "&rlr=xxxxx";
            message += "&shop=xxx.myshopify.com";
            message += "&state=xxxxxxxx";
            message += "&timestamp=1449111190";
            hmac = "xxxxxxx";
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
            
            byte[] bytes = cryptographer.ComputeHash(messageBytes);
            
            string digest = BitConverter.ToString(bytes).Replace("-", "");
            return digest == hmac.ToUpper();
