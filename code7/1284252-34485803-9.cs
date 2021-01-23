    <system.serviceModel>
        <bindings>
            <netTcpBinding>
                <binding name="netTcpEndpoint" />
            </netTcpBinding>
        </bindings>
        <client>
            <endpoint address="net.tcp://localhost:33333/chatservice/ChatService.svc"
                binding="netTcpBinding" bindingConfiguration="netTcpEndpoint"
                contract="ServiceReference1.IChatService" name="netTcpEndpoint">
                <identity>
                    <userPrincipalName value="ComputerName\UserName" />
                </identity>
            </endpoint>
        </client>
    </system.serviceModel>
