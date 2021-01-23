        private void HideForms()
        {
            int frmCount = this.MdiChildren.Count<Form>();
            if (frmCount > 0)
            {
                for (int i = 0; i < frmCount; i++)
                {
                     this.MdiChildren[i].Hide();
                }
            }
        }
