    using CERTENROLLLib;
    namespace comcerttest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cr = new CX509CertificateRequestCmc();
                var cmc2 = (IX509CertificateRequestCmc2)cr;
                cmc2.InitializeFromTemplate(X509CertificateEnrollmentContext.ContextUser, null, null);
            }
        }
    }
