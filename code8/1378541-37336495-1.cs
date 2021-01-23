    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using System.Net;
    using System.Collections.Generic;
    
    namespace WebApplication5
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var html = new HtmlDocument();
                html.LoadHtml(new WebClient().DownloadString("http://www.w3schools.com/html/html_tables.asp"));
                var root = html.DocumentNode;
                var tableNodes = root.Descendants("table");
                var items = new List<string>();
                foreach(var tbs in tableNodes.Select((tbNodes,i) => new { tbNodes = tbNodes, i = i }))
                {
                    items.Add(string.Format("<h2>&lt;table&gt; {0}<h2>", tbs.i));
                    var trs = tbs.tbNodes.Descendants("tr");
                    foreach(var tr in trs.Select((trNodes, j) => new { trNodes = trNodes, j = j }))
                    {
                        var cellCounter = 0;
                        foreach(var cell in tr.trNodes.Descendants("th"))
                        {
                            items.Add(string.Format("&lt;th&gt; [{0}][{1}][{2}] - {3}", tbs.i, tr.j, cellCounter, cell.InnerText.Trim()));
                            cellCounter++;
                        }
                        foreach (var cell in tr.trNodes.Descendants("td"))
                        {
                            items.Add(string.Format("&lt;td&gt; [{0}][{1}][{2}] - {3}", tbs.i, tr.j, cellCounter, cell.InnerText.Trim()));
                            cellCounter++;
                        }
                    }
                }
                litNumTables.Text = tableNodes.Count().ToString();
                rptTrNodes.DataSource = items;
                rptTrNodes.DataBind();
            }
        }
    }
