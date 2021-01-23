SiteMap.aspx
    <%@ Page ContentType="text/xml" Language="C#" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="Daemon.Sites.Company.SiteMap" %>
    <!-- Cache this page for 1 day -->
    <%@ OutputCache Duration="86400" VaryByParam="none" %>
    <asp:repeater id="RepeaterSiteMap" runat="server">
        <HeaderTemplate>
            <?xml version="1.0" encoding="UTF-8"?>
            <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
        </HeaderTemplate>
        <ItemTemplate>
            <url>
                <loc><%# DataBinder.Eval(Container.DataItem, "Location") %></loc>
                <priority><%# DataBinder.Eval(Container.DataItem, "Priority") %></priority>
            </url>
        </ItemTemplate>
        <FooterTemplate>
            </urlset> 
        </FooterTemplate>
    </asp:repeater>
SiteMap.aspx.cs
    public partial class SiteMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SiteMapEntry> entries = new List<SiteMapEntry>();
            entries.Add(new SiteMapEntry()
            {
                Location = "http://www.[redacted].com/",
                Priority = 1.0
            });
            entries.Add(new SiteMapEntry()
            {
                Location = "http://www.[redacted].com/About/",
                Priority = 0.9
            });
            entries.Add(new SiteMapEntry()
            {
                Location = "http://www.[redacted].com/Games/",
                Priority = 0.8
            });
            entries.Add(new SiteMapEntry()
            {
                Location = "http://www.[redacted].com/Opportunities/",
                Priority = 0.7
            });
            using (var opportunities = new OpportunityRepository())
            {
                foreach (var opportunity in opportunities.GetAll())
                {
                    var encodedTitle = URLEncoding.MakeUserFriendlyURLValue(opportunity.Title);
                    entries.Add(new SiteMapEntry()
                    {
                        Location = "http://www.[redacted].com/Opportunity/" + opportunity.ID + "/" + encodedTitle + "/",
                        Priority = 0.6
                    });
                }
            }
            entries.Add(new SiteMapEntry()
            {
                Location = "http://www.[redacted].com/News/",
                Priority = 0.5
            });
            using (var articles = new ArticleRepository())
            {
                foreach (var article in articles.GetAll())
                {
                    var encodedTitle = URLEncoding.MakeUserFriendlyURLValue(article.Title);
                    entries.Add(new SiteMapEntry()
                    {
                        Location = "http://www.[redacted].com/News/" + article.ID + "/" + encodedTitle + "/",
                        Priority = 0.4
                    });
                }
            }
            this.RepeaterSiteMap.DataSource = entries;
            this.RepeaterSiteMap.DataBind();
        }
    }
    public class SiteMapEntry
    {
        public string Location { get; set; }
        public double Priority { get; set; }
    }
