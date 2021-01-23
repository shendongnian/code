    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                "<Root>" +
                "<level1 title=\"Personal Banking\" controller=\"PersonalBanking\" description=\"Personal Banking\"  mainNavOrder=\"1\">" +
                    "<level2 title=\"Personal Deposits\" controller=\"PersonalBanking\" action=\"PersonalDeposits\" mainNavOrder=\"10\">" +
                      "<level3 title=\"Checking Accounts\" controller=\"PersonalBanking\" action=\"PersonalDeposits\" page=\"CheckingAccounts\"/>" +
                      "<level3 title=\"Savings Accounts\" controller=\"PersonalBanking\" action=\"PersonalDeposits\" page=\"SavingsAccounts\"/>" +
                      "<level3 title=\"Certificates Of Deposit\" controller=\"PersonalBanking\" action=\"PersonalDeposits\" page=\"CertificatesOfDeposit\"/>" +
                    "</level2>" +
                    "<level2 title=\"Compare Current Rates\" controller=\"PersonalBanking\" action=\"Rates\" mainNavOrder=\"20\">" +
                      "<level3 title=\"Checking Rates\" controller=\"PersonalBanking\" action=\"Rates\" page=\"CheckingAccounts\"/>" +
                    "</level2>" +
                    "<level2 title=\"Consumer Lending\" controller=\"PersonalBanking\" action=\"ConsumerLending\" mainNavOrder=\"30\">" +
                      "<level3 title=\"Auto Loans\" controller=\"PersonalBanking\" action=\"ConsumerLending\" page=\"AutoLoans\"/>" +
                      "<level3 title=\"Recreational Loans\" controller=\"PersonalBanking\" action=\"ConsumerLending\" page=\"RecreationalLoans\"/>" +
                      "<level3 title=\"Home Equity Loans\" controller=\"PersonalBanking\" action=\"ConsumerLending\" page=\"HomeEquityLoans\"/>" +
                      "<level3 title=\"Other Loans\" controller=\"PersonalBanking\" action=\"ConsumerLending\" page=\"OtherLoans\"/>" +
                    "</level2>" +
                    "<level2 title=\"Personal Services\" controller=\"PersonalBanking\" action=\"PersonalServices\"  mainNavOrder=\"40\">" +
                      "<level3 title=\"ATM &amp; Debit Cards\" controller=\"PersonalBanking\" action=\"PersonalServices\" page=\"ATMDebitCards\"/>" +
                      "<level3 title=\"Online Banking &amp; Bill Payment\" controller=\"PersonalBanking\" action=\"PersonalServices\" page=\"OnlineBankingBillPayment\"/>" +
                      "<level3 title=\"Overdraft Protection\" controller=\"PersonalBanking\" action=\"PersonalServices\" page=\"OverdraftProtection\"/>" +
                    "</level2>" +
                    "<level2 title=\"Education Center\" controller=\"EducationCenter\" mainNavOrder=\"50\"/>" +
                  "</level1>" +
                  "</Root>";
                XElement sitemapData = XElement.Parse(xml);
                var pages = sitemapData.Descendants("level1")
                            .Select(p1 => SitemapNode.GetNode(p1,1) 
                );
                List<SitemapNode> Sitemap = new List<SitemapNode>();
                Sitemap.AddRange(pages.ToList<SitemapNode>());
     
            }
            public class SitemapNode
            {
                public string Title { get; set; }
                public string Action { get; set; }
                public string Controller { get; set; }
                public string Page { get; set; }
                public string Description { get; set; }
                public bool Blank { get; set; }
                public int Level { get; set; }
                public int? mainNavOrder { get; set; }
                public string[] sections { get; set; }
                public SitemapNode[] subNodes { get; set; }
                public static SitemapNode GetNode(XElement p3, int level)
                {
                    return new SitemapNode
                    {
                        Title = (string)p3.Attribute("title"),
                        Action = (string)p3.Attribute("action") ?? "Index",
                        Controller = (string)p3.Attribute("controller"),
                        Page = (string)p3.Attribute("page") ?? "",
                        Description = (string)p3.Attribute("description") ?? "",
                        Blank = bool.Parse((string)p3.Attribute("blank") ?? "false"),
                        Level = p3.Ancestors().Count(),
                        mainNavOrder = (int?)p3.Attribute("mainNavOrder") ?? 0,
                        sections = p3.Elements("alternativeSection")
                                    .Select(n => (string)n.Attribute("name")).ToArray(),
                        subNodes = p3.Elements("level" + (level + 1).ToString()).Select(pn => GetNode(pn, level + 1)).ToArray()
                    };
                }
            }
        }
    }
