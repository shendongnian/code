        private static bool IsCompiledOnWin10AndAbove()
        {
            var typeOfMethod = typeof(IX509CertificateRequestPkcs10);
            var methodType = typeOfMethod.GetMethod("InitializeFromPrivateKey", new Type[] { typeof(X509CertificateEnrollmentContext), typeof(CX509PrivateKey), typeof(string) });
            var methodeParameters = methodType.GetParameters();
            return methodeParameters[1].ParameterType != typeof(CX509PrivateKey);
        }
