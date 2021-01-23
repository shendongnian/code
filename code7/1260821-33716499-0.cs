        //Helpfull namespaces:
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml.Serialization;
    private XmlNodeList xmlNodeList;
    ...
    XmlDocument xDoc = new XmlDocument();
    XmlReaderSettings xrs = new XmlReaderSettings();
    xrs.DtdProcessing = DtdProcessing.Parse;
    //Get Links from XML Source
    using ( XmlReader reader = XmlReader.Create( String.Format( SourceFile, Affiliate, @"MasterPage.xml" ), xrs ) )
    {
        xDoc.Load( reader );
        this.xmlNodeList = xDoc.SelectNodes( "/page/data/container/field" );
    }
    ...
    foreach ( XmlNode node in this.xmlNodeList )
    {
        LegacyLinkProcessor LegacyLink = new LegacyLinkProcessor( Affiliate )
        {
            Title = node.SelectSingleNode( "Title" ).InnerText,
            LinkContext = node.SelectSingleNode( "Link" ).InnerText
        };
        if ( LegacyLink.LinkContext.ToLower().Contains( link ) )
        {
            return LegacyLink.Title;
        }
    }
