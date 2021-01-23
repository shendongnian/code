            var l1 = new List<A>
            {
                new A
                {
                    ComputerName = Dns.GetHostName(),
                    LastLogon = DateTime.Now,
                    OperatingSystem = "Windows"
                }
            };
            var l2 = new List<B>
            {
                new B
                {
                    AgentTime = new DateTime[]{DateTime.Now},
                    ComputerName = Dns.GetHostName(),
                    LastLogonUserName = "me"
                 }
            };
            var o = from r in l2
                    join q in l1 on r.ComputerName equals q.ComputerName
                    into grp
                    from p in grp.DefaultIfEmpty()
                    select new C
                    {
                        AgentTime = r.AgentTime,
                        ComputerName = p.ComputerName,
                        LastLogon = p.LastLogon,
                        OperatingSystem = p.OperatingSystem,
                        LastLogonUserName = r.LastLogonUserName
                    };
