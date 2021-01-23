        private async Task GetSelectedItems(QuestionModel sm, Item selectedItems)
        {
            var alreadySelected = new List<Scale>();
            if (selectedScale != null)
            {
                alreadySelected.Add(selectedScale);
            }
            var itemList = (await this.uoW.ItemRepository.Get()).OrderBy(i => i.Name);
            sm.SelectedItems = itemList.Select(x => new SelectListItem
            {
                Value = x.ScaleID.ToString(),
                Text = x.NameOfScale.GetText(),
                Selected = (from a in alreadySelected where a.ItemID == x.ItemID select x).Any()
            });
        }
