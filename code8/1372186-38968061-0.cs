    <configuration>
        <configSections>
            <sectionGroup name="businessObjects">
                <sectionGroup name="crystalReports">
                    <section name="crystalReportViewer" type="System.Configuration.NameValueSectionHandler"/>
                </sectionGroup>
            </sectionGroup>
        </configSections>
        <businessObjects>
            <crystalReports>
                <crystalReportViewer>
                    <add key="UseBrowserLocale" value="true"/>
                    <add key="resourceURI" value="http://localhost/aspnet_client/system_web/4_0_30319/crystalreportviewers13" />
                </crystalReportViewer>
            </crystalReports>
        </businessObjects>
    </configuration>
