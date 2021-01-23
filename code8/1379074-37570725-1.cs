    using System;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    namespace api.valbruna.print.Controllers
    {
    public class PrintController : ApiController
    {
        // POST api/print
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            try
            {
                // parse the content recieved from the client
                var content = request.Content.ReadAsStringAsync().Result;
                // decode the content, certain characters such as 
                // '&' get encoded to URL lingo such as '%26'
                content = HttpUtility.UrlDecode(content);
                // split the string into 3 seperate parts
                String[] str = content.Split('&');
                // remove the equal sign from the first string
                str[0] = str[0].Trim('=');
                // compile the arguments command line string
                // should finish to look something like this:
                // "C:\Program Files (x86)\CoolUtils\Total PDF PrinterX\PDFPrinterX.exe" "C:\print.pdf" -p"\\PRINTERS\PRTFTW_OFIT" -ap Default -log "C:\inetpub\logs\CoolUtils\log-ValShip-155320-4.txt" -verbosity detail"
                String arguments = "\"" + str[0] + "\" -p\"\\\\PRINTERS\\" + str[1] +
                                   "\" -ap Default -log \"C:\\inetpub\\logs\\CoolUtils\\log-" + str[2] +
                                   ".txt\" -verbosity detail";
                // file location for PDFPrinterX.exe
                String file = @"C:\Program Files (x86)\CoolUtils\Total PDF PrinterX\PDFPrinterX.exe";
                // start the process
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = file;
                startInfo.Arguments = arguments;
                process.StartInfo = startInfo;
                process.Start();
                return new HttpResponseMessage() { Content = new StringContent(content) };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage() { Content = new StringContent(e.Message) };
            }
        }
    }
    }
