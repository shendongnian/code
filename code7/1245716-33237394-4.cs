    <!-- GUI.exe.config -->
    <configuration>
    
        <configSections>
            <sectionGroup name="userSettings" ... >
                <section name="GUI.GuiSettings" ... />
            </sectionGroup>
            <sectionGroup name="applicationSettings" ... >
                <section name="GUI.GuiSettings" ... />
            </sectionGroup>
        </configSections>
        
        <userSettings>
            <GUI.GuiSettings>
                <setting name="SomeGuiUserSetting" serializeAs="String">
                    <value>Some GUI user setting</value>
                </setting>
            </GUI.GuiSettings>
        </userSettings>
        
        <applicationSettings>
            <GUI.GuiSettings>
                <setting name="SomeGuiAppSetting" serializeAs="String">
                    <value>Some GUI app setting</value>
                </setting>
            </GUI.GuiSettings>
        </applicationSettings>
        
    </configuration>
