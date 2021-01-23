    <!-- GUI.exe.config -- merged configuration sections -->
    <configuration>
        <configSections>
            <sectionGroup name="userSettings" ... >
                <section name="GUI.GuiSettings" ... />
                <section name="CLI.CliSettings" ... />
            </sectionGroup>
            <sectionGroup name="applicationSettings" ... >
                <section name="GUI.GuiSettings" ... />
                <section name="CLI.CliSettings" ... />
            </sectionGroup>
        </configSections>
        
        <userSettings>
            <GUI.GuiSettings>
                <setting name="SomeGuiUserSetting" serializeAs="String">
                    <value>Some GUI user setting</value>
                </setting>
            </GUI.GuiSettings>
            <CLI.CliSettings>
                <setting name="SomeUserCliSetting" serializeAs="String">
                    <value>Some CLI user setting</value>
                </setting>
            </CLI.CliSettings>
        </userSettings>
        
        <applicationSettings>
            <GUI.GuiSettings>
                <setting name="SomeGuiAppSetting" serializeAs="String">
                    <value>Some gui app setting</value>
                </setting>
            </GUI.GuiSettings>
            <CLI.CliSettings>
                <setting name="SomeAppCliSetting" serializeAs="String">
                    <value>Some CLI app setting</value>
                </setting>
            </CLI.CliSettings>
        </applicationSettings>
        
    </configuration>
