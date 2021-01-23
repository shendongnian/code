     public JsonResult getCultureMeaning(string word, string languagePair)
            {
                string languagePair = "en|" + langua + "";
                string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", word, languagePair);
                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.UTF8;
                string result = webClient.DownloadString(url);
                result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
                result = result.Substring(result.IndexOf(">") + 1);
                result = result.Substring(0, result.IndexOf("</span>"));
                result = HttpUtility.HtmlDecode(result.Trim());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
