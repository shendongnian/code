            public string RsaEncryptPwJavaScript(string pw, string rsaPublicKey)
            {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePrefix = "MyNamespace.Typo3Js";
            var keyParts = rsaPublicKey.Split(':');
            using (var engine = new V8ScriptEngine())
            {
                engine.Execute("var navigator = { 'appName': 'Chrome' };");
                engine.Execute(GetResource(assembly, resourcePrefix + ".base64.js"));
                engine.Execute(GetResource(assembly, resourcePrefix + ".prng4.js"));
                engine.Execute(GetResource(assembly, resourcePrefix + ".rng.js"));
                engine.Execute(GetResource(assembly, resourcePrefix + ".jsbn.js"));
                engine.Execute(GetResource(assembly, resourcePrefix + ".rsa.js"));
                engine.Execute(GetEncryptJsCode());
                return engine.Script.encryptPw(pw, keyParts[0], keyParts[1]);
            }
            }
            private string GetEncryptJsCode()
            {
                 //Code from Typo3 / fe_login.js - this.encryptPasswordAndSubmitForm
                 return @"function encryptPw(pw, publicKeyModulus, exponent) {
                var rsa, encryptedPassword;
                rsa = new RSAKey();
                rsa.setPublic(publicKeyModulus, exponent);
                encryptedPassword = rsa.encrypt(pw);
                return 'rsa:' + hex2b64(encryptedPassword);
            }";
            }
            private string GetResource(Assembly assembly, string resourceName)
            {
                 using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                 using (StreamReader reader = new StreamReader(stream))
                 {
                     return reader.ReadToEnd();
                 }
             }
