    [HttpDelete]
        public PartialViewResult DeleteItem(int itemId, int page)
        {
            this.dbService.DeletItem(expenseId);
            return PartialView("SubView", this.GetPagedList(page));
        }
