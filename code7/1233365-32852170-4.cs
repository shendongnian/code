    var divName = item.SelectSingleNode("div[@class='col-md-20']/div[@class='name']");
    var nodeA = divName.SelectSingleNode("a");
    st.Name = nodeA.InnerText;
    st.Url = nodeA.Attributes["href"].Value;
    string rawText = divName.SelectSingleNode("small/em").InnerText;
    st.Company = HttpUtility.HtmlDecode(rawText.Trim());
