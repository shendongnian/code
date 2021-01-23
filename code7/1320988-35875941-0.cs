        public List<Network> GetStandardPgs(Datacenter selectedDC = null)
        {
            List<Network> lstPortGroups = new List<Network>();
            ManagedObjectReference DcMoRef = new ManagedObjectReference();
            if (selectedDC != null)
            {
                DcMoRef = selectedDC.MoRef;
            }
            else
            {
                DcMoRef = null;
            }
            List<EntityViewBase> appPortGroups = _vmwarecontext.FindEntityViews(typeof(Network), DcMoRef, null, null);
            if (appPortGroups != null)
            {
                foreach (EntityViewBase appPortGroup in appPortGroups.Where(x => x.GetType() == typeof(Network)))
                {
                    lstPortGroups.Add((Network)appPortGroup);
                }
                return lstPortGroups;
            }
            else
            {
                return null;
            }
        }
