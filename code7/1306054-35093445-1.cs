    using System;
    using System.Web.Services;
    using System.Web.UI;
    
    public class main : Page {
        protected void Page_Load(object sender, EventArgs e) { }
    
        [WebMethod]
        public static string processData(FormData formData) {
            //access your data object here e.g.:
            string val1 = formData.value1;
            string val2 = formData.value2;
            string val3 = formData.value3;
    						
            return val1;
        }
        // the FormData Class here has to have the same properties as your JavaScript Object!
        public class FormData {
            public FormData() { }
            public string value1 { get; set; }
            public string value2 { get; set; }
            public string value3 { get; set; }
        }
    }
