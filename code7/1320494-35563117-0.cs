        public ActionResult getgrouptree()
        {
            List<DeviceGroup> rootgroup = db.DeviceGroups.Where(a => a.ParentGroupID == 0).ToList();
            foreach (var item in rootgroup)
            {
                item.SubGroup = devicesubgroup(item);
               
            }
            return View(rootgroup);
        }
        public List<DeviceGroup> devicesubgroup(DeviceGroup subgroup1)
        {
            List<DeviceGroup> subgroup = new List<DeviceGroup>();
            int count = db.DeviceGroups.Where(a => a.ParentGroupID == subgroup1.GroupID).Count();
            if (count >= 1)
            {
                subgroup = subgroup1.SubGroup = db.DeviceGroups.Where(a => a.ParentGroupID == subgroup1.GroupID).ToList();
                foreach (var item in subgroup)
                {
                    devicesubgroup(item);
                }
            }
            return subgroup;
