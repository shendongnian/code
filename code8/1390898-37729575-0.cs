    _kernelTraceEventParser = new KernelTraceEventParser(_source);
    _kernelTraceEventParser.TcpIpConnect += KernelParserOnTcpIpConnect;
    
    private void KernelParserOnTcpIpConnect(TcpIpConnectTraceData tcpIpConnectTraceData)
    {
         lokalAddress = tcpIpConnectTraceData.saddr + ":" + tcpIpConnectTraceData.sport;
         serverAddress = tcpIpConnectTraceData.daddr + ":" + tcpIpConnectTraceData.dport;
    }
