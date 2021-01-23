    CustomBinding binding = new CustomBinding();
                SymmetricSecurityBindingElement ssbe =
                    SecurityBindingElement.CreateSspiNegotiationBindingElement(true);
                // Add the SymmetricSecurityBindingElement to the BindingElementCollection.
                binding.Elements.Add(ssbe);
                binding.Elements.Add(new TextMessageEncodingBindingElement());
                binding.Elements.Add(new HttpTransportBindingElement());
