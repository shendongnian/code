    static void Main(string[] args)
        {
            string[] List = { "k36062", "k15547", "j63390" };
            foreach(string line in List)
            {
                Console.WriteLine(DownloadFile(line, "pdf"));
            }
            Console.ReadKey();
        }
        private static string DownloadFile(string pdfId, string filetype)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile("http://munifilings.com/pdfs/0/" + pdfId + ".pdf", "C:\\Temp\\files\\" + filetype + "_" + pdfId + ".pdf");
                }
                return "Downloaded No errors";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
