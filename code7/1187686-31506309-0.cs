        [HttpPost]
        [BasicAuthentication(username: "x", password: "y", BasicRealm = "z")]
        public HttpStatusCodeResult ChargeBeeWebhook()
        {
            if (ModelState.IsValid)
            {          
                Event chargeBeeEvent = new Event(Request.InputStream);
                EventTypeEnum? eventType = chargeBeeEvent.EventType;
                Event.EventContent eventContent = chargeBeeEvent.Content;
                if (eventType == EventTypeEnum.SubscriptionCreated)
                {
                    Subscription subscription = eventContent.Subscription;
                    Customer customer = eventContent.Customer;
                    // more stuff
                }          
            
                return new HttpStatusCodeResult(200);
            }
            else
            {
                return new HttpStatusCodeResult(400); // bad request
            }
        }
