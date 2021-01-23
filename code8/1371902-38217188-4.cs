        public object getFBFunctionMenu(){
            Models.Messenger fbmsg = new Models.Messenger();
            fbmsg.ChannelData = new MessengerChannelData { notification_type = "NO_PUSH", attachment = new MessengerAttachment { payload = new MessengerPayload() } };
            fbmsg.ChannelData.attachment.type = "template";
            fbmsg.ChannelData.attachment.payload.template_type = "generic";
            List<MessengerElement> e = new List<MessengerElement>();
            List<MessengerButton> bs = new List<MessengerButton>();
            bs.Add(new MessengerButton{type = "web_url",title = "Facebook",url ="http://www.facebook.com/"});
            bs.Add(new MessengerButton{type = "web_url",title = "Google",url ="http://www.google.com/"});
            bs.Add(new MessengerButton{type = "web_url",title = "Amazon",url ="http://www.amazon.com/"});
            e.Add(new MessengerElement
            {
                title = "My Favorte Site",
                subtitle = "some descript",
                item_url = "http://localhost/",
                image_url = "http://loalhost/img.png",
                buttons = bs.ToArray()
            });
            fbmsg.ChannelData.attachment.payload.elements = e.ToArray();
            return fbmsg.ChannelData;
        }
