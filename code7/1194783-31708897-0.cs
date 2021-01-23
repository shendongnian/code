            private static SecurityToken ConvertBearerTokenTextToSecurityToken(string tokenText)
        {
            SecurityToken token = null;
            // ConfigSections must be added to App.Config in order for this line to work - this section must be right after the <configuration> node
            //<configSections>
            //  <!--WIF 4.5 sections -->
            //  <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
            //  <section name="system.identityModel.services" type="System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
            //</configSections>
            //SecurityTokenHandlerCollection handlers = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.SecurityTokenHandlers;
            using (StringReader stringReader = new StringReader(tokenText))
            {
                using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
                {
                    if (!xmlReader.ReadToFollowing("Assertion"))
                    {
                        throw new Exception("Assertion not found!");
                    }
                    SecurityTokenHandlerCollection collection = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
                    token = collection.ReadToken(xmlReader.ReadSubtree()); 
                }
            }
            return token;
        }
