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
            Match mVS = Regex.Match(html, "id=\"__VIEWSTATE\" value=\"(.*?)\"", RegexOptions.Singleline);
            Match mEV = Regex.Match(html, "id=\"__EVENTVALIDATION\" value=\"(.*?)\"", RegexOptions.Singleline);
            ///////////////////////////////////////SEARCH///////////////////////////////////////////////////
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
            foreach (var i in param)
            {
                post += WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value) + "&";
            }
            var data = Encoding.UTF8.GetBytes(post);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.CookieContainer = cc;
            request.Referer = URI;
            request.Method = "POST";
            request.Headers.Add("Cache-Control", "no-cache");
            request.Accept = "*/*";
            request.Headers.Add("Accept-Language", "pt-PT,pt;q=0.8,en-US;q=0.6,en;q=0.4,es;q=0.2");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Origin", "https://www.citius.mj.pt");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-MicrosoftAjax: Delta=true");
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            File.WriteAllText("D:\\tmp1.txt", responseString);
            ////////////////////////////////////////////NEXT PAGE//////////////////////////////////////////
            param.Clear();
            string[] split = responseString.Split('|');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "__VIEWSTATE") param.Add("__VIEWSTATE", split[i + 1]);
                if (split[i] == "__EVENTVALIDATION") param.Add("__EVENTVALIDATION", split[i + 1]);
            }
            param.Add("ctl00$ContentPlaceHolder1$ScriptManager1", "ctl00$ContentPlaceHolder1$upResultados|ctl00$ContentPlaceHolder1$Pager1$lnkNext");
            param.Add("ctl00$ContentPlaceHolder1$rbtlTribunais", "False");
            param.Add("ctl00$ContentPlaceHolder1$ddlTribunais", "- Todos os Tribunais -");
            param.Add("ctl00$ContentPlaceHolder1$rblDias", "todos");
            param.Add("__EVENTTARGET", "ctl00$ContentPlaceHolder1$Pager1$lnkNext");
            param.Add("__EVENTARGUMENT", "");
            param.Add("__LASTFOCUS", "");
            //param.Add("__VIEWSTATE", mVS.Groups[1].Value);
            //param.Add("__EVENTVALIDATION", mEV.Groups[1].Value);
            param.Add("__ASYNCPOST", "true");
            post = "";
            foreach (var i in param)
            {
                post += WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value) + "&";
            }
            data = Encoding.UTF8.GetBytes(post);
            request = (HttpWebRequest)WebRequest.Create(URI);
            request.CookieContainer = cc;
            request.Referer = URI;
            request.Method = "POST";
            request.Headers.Add("Cache-Control", "no-cache");
            request.Accept = "*/*";
            request.Headers.Add("Accept-Language", "pt-PT,pt;q=0.8,en-US;q=0.6,en;q=0.4,es;q=0.2");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Origin", "https://www.citius.mj.pt");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-MicrosoftAjax: Delta=true");
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            response = (HttpWebResponse)request.GetResponse();
            responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            File.WriteAllText("D:\\tmp2.txt", responseString);
            int y = 1;
        }
    }
