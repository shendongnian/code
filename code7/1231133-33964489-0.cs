	public async Task<IpVersion> GetCurrentIpVersion()
	{
		try
		{
			// resolves domain name to IP addresses (may contain several)
			var endPointPairs = await DatagramSocket.GetEndpointPairsAsync(new HostName("google.com"), "0");
			if (endPointPairs == null)
			{
				return IpVersion.None;
			}
			// detect which IP version is supported
			var result = IpVersion.None;
			foreach (var endPoint in endPointPairs)
			{
				if (endPoint.RemoteHostName != null)
				{
					if (endPoint.RemoteHostName.Type == HostNameType.Ipv4)
					{
						result |= IpVersion.IPv4;
					}
					else if (endPoint.RemoteHostName.Type == HostNameType.Ipv6)
					{
						result |= IpVersion.IPv6;
					}
				}
			}
			return result;
		}
		catch
		{
			return IpVersion.None;
		}
	}
