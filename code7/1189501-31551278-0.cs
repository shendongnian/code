    // A
	class AccountingCenter
	{
		private List<Branch> m_branches = new List<Branch>();
		public string Id { get; private set; }
		public ReadOnlyCollection<Branch> Branches { get { return m_branches.AsReadOnly(); } }
		public AccountingCenter(string id, IEnumerable<string> branchIds = null)
		{
			Id = id;
			if (branchIds != null)
			{
				foreach(var b in branchIds)
				{
					AddBranch(b);
				}
			}
		}
		public void AddBranch(string id)
		{
			m_branches.Add(new Branch(id, this));
		}
	}
    // C
	class Branch
	{
		private AccountingCenter m_parentCenter;
		public string BranchId { get { return m_parentCenter.Id + "-" + Id; } } // or whatever the combined implementation would be
		public string Id { get; private set; }
		public Branch(string id, AccountingCenter center)
		{
			Id = id;
			m_parentCenter = center;
		}
	}
    // CProvider
	class AccountingCenterContainer
	{
		private Dictionary<string, Branch> m_BranchIdToBranchMap = new Dictionary<string, Branch>();
		public AccountingCenterContainer(IEnumerable<AccountingCenter> centers)
		{
			foreach (var c in centers)
			{
				foreach (var b in c.Branches)
				{
					m_BranchIdToBranchMap.Add(b.BranchId, b);
				}
			}
		}
		public Branch GetBranchFromId(string branchId)
		{
			if (!m_BranchIdToBranchMap.ContainsKey(branchId))
			{
				throw new ArgumentException("ID " + branchId + " does not correspond to any known branch");
			}
			return m_BranchIdToBranchMap[branchId];
		}
	}
    // B
	class Payment
	{
		public string BranchId { get; private set; }
		public Payment(string branchId)
		{
			BranchId = branchId;
		}
		public void Process(AccountingCenterContainer container)
		{
			Branch b = container.GetBranchFromId(BranchId);
			// process...
		}
	}
