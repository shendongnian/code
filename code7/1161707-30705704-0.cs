        public string GetAnimalDetails()
        {
            string typo = string.Empty;
            typo = DropDownListBranch.SelectedValue;
            if (!string.IsNullOrEmpty(typo) && !string.IsNullOrEmpty(DropDownListMilestone.SelectedValue))
            {
                typo = typo + " ";
            }
            typo = typo + DropDownListMilestone.SelectedValue;
            if (!string.IsNullOrEmpty(typo) && !string.IsNullOrEmpty(DropDownListType.SelectedValue))
            {
                typo = typo + " ";
            }
            typo = typo + DropDownListType.SelectedValue;
            if (!string.IsNullOrEmpty(typo) && !string.IsNullOrEmpty(DropDownListVersion.SelectedValue))
            {
                typo = typo + " - ";
            }
            typo = typo + DropDownListVersion.SelectedValue;
            return typo;
        }
        protected void DropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnimalDetails.Text = GetAnimalDetails();
        }
        protected void DropDownListMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnimalDetails.Text = GetAnimalDetails();
        }
        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnimalDetails.Text = GetAnimalDetails();
        }
        protected void DropDownListVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnimalDetails.Text = GetAnimalDetails();
        }
