    <!-- CLI.exe.config -->
    <configuration>
        <!-- setting section definitions -->
        <configSections>
            <sectionGroup name="userSettings" ... >
                <section name="CLI.CliSettings" ... />
            </sectionGroup>
            <sectionGroup name="applicationSettings" ... >
                <section name="CLI.CliSettings" ... />
            </sectionGroup>
        </configSections>
        <!-- defaults for user settings (runtime changes are stored to appdata) -->
        <userSettings>
            <CLI.CliSettings>
                <setting name="SomeUserCliSetting" serializeAs="String">
                    <value>Some CLI user setting</value>
                </setting>
            </CLI.CliSettings>
        </userSettings>
        
        <!-- application settings (readonly) -->
        <applicationSettings>
            <CLI.CliSettings>
                <setting name="SomeAppCliSetting" serializeAs="String">
                    <value>Some CLI app setting</value>
                </setting>
            </CLI.CliSettings>
        </applicationSettings>
        
    </configuration>
