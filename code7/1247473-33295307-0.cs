    public class MyGlobalEventHandler : ApplicationEventHandler {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var nWebSecHttpHeaderSecurityModule = umbracoApplication.Modules["NWebSecHttpHeaderSecurityModule"] as HttpHeaderSecurityModule;
            if (nWebSecHttpHeaderSecurityModule != null) {
                nWebSecHttpHeaderSecurityModule .CspViolationReported += NWebSecHttpHeaderSecurityModule_CspViolationReported;
            }
            base.ApplicationStarted(umbracoApplication, applicationContext);
        }
        protected void NWebSecHttpHeaderSecurityModule_CspViolationReported(object sender, CspViolationReportEventArgs e)
        {
            var report = e.ViolationReport;
            var serializedReport = JsonConvert.SerializeObject(report.Details);
            // Do a thing with the report
        }
    }
