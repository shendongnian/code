        <configuration> 
       ... 
    
       <system.web> 
          ... 
          <httpModules> 
             ... 
             <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" /> 
          </httpModules>
       </system.web> 
    
       <system.webServer> 
          <validation validateIntegratedModeConfiguration="false"/> 
          <modules> 
             ... 
             <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" /> 
          </modules> 
    
    
          <handlers>
             ...
             <add name="UrlRoutingHandler" preCondition="integratedMode" verb="*" path="UrlRouting.axd" type="System.Web.HttpForbiddenHandler, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
          </handlers>
          ... 
       </system.webServer>
    </configuration>
