    using CERTENROLLLib;
    namespace comcerttest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // If you are embedding the interop types, note that you must
                // remove the `Class` suffix from generated type name in order
                // to instantiate it. See link at the bottom for explanation:
                var cr = new CX509CertificateRequestCmc();
                var cmc2 = (IX509CertificateRequestCmc2)cr;
                cmc2.InitializeFromTemplate(X509CertificateEnrollmentContext.ContextUser, null, null);
            }
        }
    }
