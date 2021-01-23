     public static List<SelectListItem> AdCodeList()
            {
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "--Select--", Value = null, Selected = true });
                using (CrmKolmEntities entities = new CrmKolmEntities())
                {
                    var allActiveCAdCodes = entities.AdCodes.Where(x => x.IsDeleted == false).ToList();
                    if (allActiveCAdCodes.Count() > 0)
                    {
                        foreach (var adCode in allActiveCAdCodes)
                        {
                            list.Add(new SelectListItem { Text = adCode.AdCodeName, Value = adCode.AdCodeId.ToString() });
                        }
                    }
                }
                return list;
            }
