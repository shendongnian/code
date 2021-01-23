    public static Boolean SendToOneUser(String userToken, String msgTitle)
        {
            using (var client = new HttpClient())
            {
                var message = new VmFcmMessage();
                message.to = userToken;
                message.notification = new VmFcmNotification()
                {
                    title = msgTitle,
                    //body = desc,
                    //text = desc
                };
                string postBody = JsonConvert.SerializeObject(message).ToString();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", FcmConstants.SERVER_ID);
                var response = client.PostAsync("https://fcm.googleapis.com/fcm/send", new StringContent(postBody, Encoding.UTF8, "application/json"));
                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                //TODO get response and handle send messages
                return true;
            }
        }
