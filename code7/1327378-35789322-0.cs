    			var _response = null;
			
			
			//send http request to platform, get back 204
			...
			var sw = new Stopwatch();
            sw.Start();
			//subsribe to messages being published
            MessagePublisher.MessageReceived += OnMessageReceived;
            try
            {
                while (true)
                {
                    if (_response != null)
                        return _response; //we got a response
                    if (sw.ElapsedMilliseconds > _messageTimeout)
                    {
                        return null; //todo handle not receiving a response from the webhooks
                    }
                }
            }
            finally
            {
                //unregister event
                MessagePublisher.MessageReceived -= OnMessageReceived;
            }
		}
		
		private void OnMessageReceived(object sender, Message message)
		{
            //TODO convert the message to a filled in webservice response
			_response = new WebServiceResponse();
		}
	}
	
	// publishes the message when the other controller receives it
	public static MessagePublisher
	{
		public static event EventHandler<Message> MessageReceived;
        public static void OnMessageReceived(Message result)
        {
            EventHandler<Message> handler = MessageReceived;
            if (handler != null)
            {
                handler(null, result);
            }
        }	
	}
