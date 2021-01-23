    var divName = item.SelectSingleNode("div[@class='col-md-20']/div[@class='name']");
    st.Name = divName.SelectSingleNode("a").InnerText;
    st.Url = divName.SelectSingleNode("a").Attributes["href"].Value;
    string rawText = divName.SelectSingleNode("small/em").InnerText;
    st.Company = HttpUtility.HtmlDecode(rawText.Trim());
