        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            GZipMessageEncodingBindingElement binding = (GZipMessageEncodingBindingElement)bindingElement;
            PropertyInformationCollection propertyInfo = this.ElementInformation.Properties;
            if (propertyInfo["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
            {
                switch (this.InnerMessageEncoding)
                {
                    case "textMessageEncoding":
                        binding.InnerMessageEncodingBindingElement = 
                            new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8);
                        break;
                    case "binaryMessageEncoding":
                        binding.InnerMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                        break;
                }
            }
        }
