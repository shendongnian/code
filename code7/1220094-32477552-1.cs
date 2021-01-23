        <siteMap defaultProvider="XmlSiteMapProvider" enabled="true">
              <providers>
                <clear />
                <add name="XmlSiteMapProvider" type="System.Web.XmlSiteMapProvider" siteMapFile="Web.sitemap" />
                <add name="XmlSiteMapProvider2" type="System.Web.XmlSiteMapProvider" siteMapFile="secondsitemapname.sitemap" />
              </providers>
            </siteMap>
