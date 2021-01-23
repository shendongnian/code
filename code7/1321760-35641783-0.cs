    string URI = "https://www.citius.mj.pt/Portal/consultas/ConsultaVendaAnuncios.aspx";
    CookieContainer cc = new CookieContainer();
    HttpWebRequest h = (HttpWebRequest)WebRequest.Create(URI);
    h.CookieContainer = cc;
    HttpWebResponse hr = (HttpWebResponse)h.GetResponse();
    using (var s = hr.GetResponseStream())
    {
        using (var r = new StreamReader(s, Encoding.UTF8))
        {
            string html = r.ReadToEnd();
            //Console.WriteLine(html);
            Match mVS = Regex.Match(html, "id=\"__VIEWSTATE\" value=\"(.*?)\"", RegexOptions.Singleline);
            //Console.WriteLine(mVS.Groups[1].Value);
            Match mEV = Regex.Match(html, "id=\"__EVENTVALIDATION\" value=\"(.*?)\"", RegexOptions.Singleline);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ctl00$ContentPlaceHolder1$ScriptManager1", "ctl00$ContentPlaceHolder1$ScriptManager1|ctl00$ContentPlaceHolder1$btnSearch");
            param.Add("__EVENTTARGET", "");
            param.Add("__EVENTARGUMENT", "");
            param.Add("__LASTFOCUS", "");
            param.Add("__VIEWSTATE", mVS.Groups[1].Value);
            param.Add("__EVENTVALIDATION", mEV.Groups[1].Value);
            param.Add("ctl00$ContentPlaceHolder1$rbtlTribunais", "False");
            param.Add("ctl00$ContentPlaceHolder1$ddlTribunais", "- Todos os Tribunais -");
            param.Add("ctl00$ContentPlaceHolder1$rblDias", "todos");
            param.Add("__ASYNCPOST", "true");
            param.Add("ctl00$ContentPlaceHolder1$btnSearch", "Pesquisar");
            string post = "";
            foreach (var i in param) post += WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value) + "&";
            var data = Encoding.UTF8.GetBytes(post);
            Console.WriteLine(data.Length);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.CookieContainer = cc;
            request.Referer = URI;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
            request.Headers.Add("Origin", "https://www.citius.mj.pt");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-MicrosoftAjax: Delta=true");
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
        }
    }
