	private string GetWhere()
        {
            return string.Format(where,
                ddlTaskName.SelectedValue,
                ddlService.SelectedValue,
                ddlStatus.SelectedValue,
                ddlDueDate.SelectedValue,
                ddlOwner.SelectedValue,
                ddlClient.SelectedValue,
                ddlSite.SelectedValue,
                ddlPractice.SelectedValue,
                ddlProvider.SelectedValue
                );
        }
        private string GetGridSelect()
        {
            return string.Concat(StrMainQuery, _from, GetWhere());
        }
