        public IEnumerable<SelectListItem> SelectList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            var listOfCat1 = db.TcSets.ToList();
            if (listOfCat1 != null)
            {
                if (listOfCat1.Count>0)
                {
                    foreach (var item in listOfCat1)
                    {
                        SelectListItem sVM = new SelectListItem();
                        sVM.Value = item.Id.ToString();
                        sVM.Text = item.Name;
                        selectList.Add(sVM);
                    }
                }
            }
            return selectList.AsEnumerable();
        }
