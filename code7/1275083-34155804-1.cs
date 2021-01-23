	public class CidrCompressor
	{    
		private readonly Regex _subnetRegex = new Regex(@"^(?<net>\d+\.\d+\.\d+)\.0$", RegexOptions.Compiled); 
		private Regex _currentNetRegex;
		private string _currentNet;
		private int _lastSubIp;
		
		private List<string> _ipList = new List<string>();
		
		private void AddReceivedInSubnet()
		{
			for (var i = 0; i < _lastSubIp; ++i)
			{
				_ipList.Add(string.Format("{0}.{1}", _currentNet, i));
			}
			_currentNetRegex = null;
		}
		
		public void Add(string ip)
		{
			var m = _subnetRegex.Match(ip);
			if (m.Success)
			{
				// Matches *.0
				// Start matching subnet
				_currentNet = m.Groups["net"].Value;
				_currentNetRegex = new Regex(string.Format(@"^{0}\.(?<subIp>\d+)$", _currentNet));			
				_lastSubIp = 0;
			}
			else if (_currentNetRegex != null)
			{
				// Currently matching a subnet
				m = _currentNetRegex.Match(ip);
				
				if (m.Success)
				{
					var subIp = int.Parse(m.Groups["subIp"].Value);
	
					if (subIp == _lastSubIp + 1)
					{
						// See if we have received a full subnet
						if (subIp == 255)
						{
							_ipList.Add(_currentNet + "/24");
							_currentNetRegex = null;					
						}
						else
						{
							_lastSubIp = subIp;
						}
					}
					else
					{
						// Not continuous so add indivudial IPs
						AddReceivedInSubnet();
						Add(ip);
					}
				}
				else
				{
					// Received IP in different net before .255
					// Add all IPs received
					AddReceivedInSubnet();
	
					// Process ip we received
					Add(ip);
				}
			}
			else
			{
				_ipList.Add(ip);
			}
		}
		
		public IEnumerable<string> IpList 
		{
			get
			{
				return _ipList;
			}
		}
	}
