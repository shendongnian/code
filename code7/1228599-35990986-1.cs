        X509Certificate2 GetCert()
        {
            var stx = File.Open(Path.Combine(TestContext.DeploymentDirectory, "thecertfile.pfx"), FileMode.Open);
            using (BinaryReader br = new BinaryReader(stx))
            {
                return new X509Certificate2(br.ReadBytes((int)br.BaseStream.Length), "password");
            }
        }
        [TestMethod, DeploymentItem("thecertfile.pfx")]
        public void Signing_FlameTest()
        {
    	    var cert = GetCert();
         	Assert.IsNotNull(cert, "GetCert failed");
        }
