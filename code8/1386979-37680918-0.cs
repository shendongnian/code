        static string ftpUser = ConfigurationManager.AppSettings["ftpUser"].ToString();
        static string ftpPass = ConfigurationManager.AppSettings["ftpPass"].ToString();
        static string serverPath = ConfigurationManager.AppSettings["jsonuri"].ToString() + dt.bedrijfsNaam + ".json";
        static string json;
        public static void post(string reqCat)
        {
            WebRequest hwr = WebRequest.Create(serverPath);
            hwr.Method = WebRequestMethods.Ftp.UploadFile;
            hwr.Credentials = new NetworkCredential(ftpUser, ftpPass);
            if (reqCat == "bvg")
            {
                json = "[\"bedrijfsNaam\":\"" + bedrijfsNaam + "\"," +
                                "\"ContPers\":\"" + ContPers + "\"," +
                                "\"TelNum\":\"" + TelNum + "\"," +
                                "\"email\":\"" + email + "\"," +
                                "\"Land\":\"" + Land + "\"," +
                                "\"Plaats\":\"" + Plaats + "\"," +
                                "\"PostCode\":\"" + PostCode + "\"]";
                using (var sw = new StreamWriter(hwr.GetRequestStream()))
                {
                    sw.Write(json);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
