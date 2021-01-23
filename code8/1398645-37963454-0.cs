    ws.Column(44).Style.Font.SetFontColor(XLColor.AirForceBlue)
        .Font.SetUnderline(XLFontUnderlineValues.Single;
    url = folderPath + "type=testPhoto&userName="; 
    for (int i = 2; i <= result.Count + 1; i++)
    {
        ws.Cell(i, 44).SetValue("Download").Hyperlink =
            new XLHyperlink(url + Convert.ToString(result[i - 2].testCode), "Download");
    }
