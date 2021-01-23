    @{
          var conf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            var section = (System.Web.Configuration.SessionStateSection)conf.GetSection("system.web/sessionState");
            string timeout = section.Timeout.TotalMinutes.ToString();
     }
    
    <script>
    $(document).ready(function () {
    
                    var time = @timeout * 1000 * 60;
                    var timeout;
                    var isLogout = false;
    
                    timeout = setTimeout(function() {
                        //Things you need to do
                            isLogout = true;
                        
                    }, time);
    
                    $(document).on('click', function () {
                        if (!isLogout) {
                            clearTimeout(timeout);
                            timeout = setTimeout(function() {
                                //Things you need to do
                                 isLogout = true;
                            }, time);
                        }
                    });
                });
    </script>
